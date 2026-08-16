using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Desktop
{
    public partial class RestockForm : Form
    {
        private readonly HttpClient _httpClient;
        private List<ProductDto> _productsList = new List<ProductDto>();
        private List<RestockDetailDto> _currentInvoiceItems = new List<RestockDetailDto>();
        private int? _selectedHeaderId = null;

        private static HttpClient CreateHttpsClient()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            return new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7191/")
            };
        }

        public RestockForm(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient ?? CreateHttpsClient();
        }

        public RestockForm() : this(CreateHttpsClient())
        {
        }

        private async void RestockForm_Load(object sender, EventArgs e)
        {
            ApplyBoldFonts();
            await LoadProductsAsync();
            await LoadRestockHistoryAsync();
        }

        private void ApplyBoldFonts()
        {
            try
            {
                if (dgvCart != null)
                {
                    dgvCart.DefaultCellStyle.Font = new Font(dgvCart.Font, FontStyle.Bold);
                    dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font(dgvCart.Font, FontStyle.Bold);
                }

                if (dgvHistory != null)
                {
                    dgvHistory.DefaultCellStyle.Font = new Font(dgvHistory.Font, FontStyle.Bold);
                    dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font(dgvHistory.Font, FontStyle.Bold);
                }
            }
            catch { }
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ProductDto>>("api/products");
                if (response != null && cmbProducts != null)
                {
                    _productsList = response;
                    cmbProducts.DataSource = _productsList;
                    cmbProducts.DisplayMember = "Name";
                    cmbProducts.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في الاتصال بالـ API لجلب المنتجات: {ex.Message}", "خطأ API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRestockHistoryAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<RestockHeaderDto>>("api/restock");
                if (dgvHistory != null && response != null)
                {
                    dgvHistory.DataSource = response.Select(h => new
                    {
                        رقم_الفاتورة = h.Id,
                        اسم_المورد = h.SupplierName,
                        تاريخ_التوريد = h.RestockDate.ToString("yyyy-MM-dd HH:mm"),
                        الإجمالي = h.TotalAmount
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب سجل الفواتير من الـ API: {ex.Message}", "خطأ API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cmbProducts?.SelectedItem is not ProductDto selectedProduct)
            {
                MessageBox.Show("يرجى اختيار صنف أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qty = (int)numQuantity.Value;
            decimal buyPrice = numPurchasePrice.Value;

            if (qty <= 0)
            {
                MessageBox.Show("يرجى إدخال كمية صالحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingItem = _currentInvoiceItems.FirstOrDefault(x => x.ProductId == selectedProduct.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += qty;
                existingItem.PurchasePrice = buyPrice;
            }
            else
            {
                _currentInvoiceItems.Add(new RestockDetailDto
                {
                    ProductId = selectedProduct.Id,
                    ProductName = selectedProduct.Name,
                    Quantity = qty,
                    PurchasePrice = buyPrice
                });
            }

            RefreshCurrentInvoiceGrid();
        }

        private void RefreshCurrentInvoiceGrid()
        {
            if (dgvCart != null)
            {
                dgvCart.DataSource = null;
                dgvCart.DataSource = _currentInvoiceItems.Select(x => new
                {
                    اسم_الصنف = x.ProductName,
                    الكمية = x.Quantity,
                    سعر_الشراء = x.PurchasePrice,
                    الإجمالي = x.Quantity * x.PurchasePrice
                }).ToList();
            }

            if (lblTotalAmount != null)
            {
                lblTotalAmount.Text = $"{_currentInvoiceItems.Sum(x => x.Quantity * x.PurchasePrice):N2} ريال";
            }
        }

        private async void btnSaveRestock_Click(object sender, EventArgs e)
        {
            if (!_currentInvoiceItems.Any())
            {
                MessageBox.Show("سلة التوريد فارغة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dto = new CreateRestockDto
                {
                    SupplierName = string.IsNullOrWhiteSpace(txtSupplier.Text) ? "غير محدد" : txtSupplier.Text,
                    Items = _currentInvoiceItems
                };

                var response = await _httpClient.PostAsJsonAsync("api/restock", dto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("تم حفظ الفاتورة عبر الـ API وتعديل المخزون بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PrintInvoicePreview();

                    _currentInvoiceItems.Clear();
                    RefreshCurrentInvoiceGrid();
                    txtSupplier.Clear();
                    await LoadRestockHistoryAsync();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"فشل الحفظ: {err}", "خطأ API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ اتصال بالـ API: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvHistory == null) return;

            try
            {
                var row = dgvHistory.Rows[e.RowIndex];
                _selectedHeaderId = Convert.ToInt32(row.Cells[0]?.Value);

                if (_selectedHeaderId.HasValue)
                {
                    var details = await _httpClient.GetFromJsonAsync<List<RestockDetailDto>>($"api/restock/{_selectedHeaderId.Value}");
                    if (details != null)
                    {
                        _currentInvoiceItems = details;
                        txtSupplier.Text = row.Cells[1]?.Value?.ToString() ?? "غير محدد";
                        RefreshCurrentInvoiceGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء جلب التفاصيل: {ex.Message}", "خطأ API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeleteRestock_Click(object sender, EventArgs e)
        {
            if (!_selectedHeaderId.HasValue)
            {
                MessageBox.Show("يرجى النقر المزدوج على فاتورة من الجدول السفلي لتحديدها أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("هل أنت تأكد من حذف الفاتورة المحددة؟ سيتم خصم الكميات الموردة من المخزون تلقائياً.", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var response = await _httpClient.DeleteAsync($"api/restock/{_selectedHeaderId.Value}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("تم حذف الفاتورة وتعديل المخزون بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _selectedHeaderId = null;
                        _currentInvoiceItems.Clear();
                        RefreshCurrentInvoiceGrid();
                        txtSupplier.Clear();
                        await LoadRestockHistoryAsync();
                    }
                    else
                    {
                        var err = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"خطأ أثناء الحذف: {err}", "خطأ API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (!_currentInvoiceItems.Any())
            {
                MessageBox.Show("لا توجد عناصر في السلة لطباعتها!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintInvoicePreview();
        }

        private void PrintInvoicePreview()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintInvoicePage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600,
                StartPosition = FormStartPosition.CenterScreen
            };

            previewDialog.ShowDialog();
        }

        private void PrintInvoicePage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 11, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10, FontStyle.Bold);
            Font regularFont = new Font("Arial", 10, FontStyle.Regular);

            int startX = 50;
            int startY = 40;
            int offsetY = 30;

            g.DrawString("Van Sales System - نظام المبيعات والمخزون", headerFont, Brushes.Navy, new PointF(200, startY));
            startY += offsetY + 10;
            g.DrawString("=== فاتورة توريد وتزويد مخزون ===", subHeaderFont, Brushes.Black, new PointF(260, startY));
            startY += offsetY;

            g.DrawString($"المورد / المصدر: {txtSupplier.Text}", bodyFont, Brushes.Black, new PointF(startX, startY));
            g.DrawString($"تاريخ التوريد: {DateTime.Now:yyyy-MM-dd HH:mm}", bodyFont, Brushes.Black, new PointF(500, startY));
            startY += offsetY + 10;

            g.DrawLine(Pens.Black, startX, startY, 750, startY);
            startY += 5;
            g.DrawString("اسم الصنف", bodyFont, Brushes.Black, new PointF(startX, startY));
            g.DrawString("الكمية", bodyFont, Brushes.Black, new PointF(350, startY));
            g.DrawString("سعر الشراء", bodyFont, Brushes.Black, new PointF(480, startY));
            g.DrawString("الإجمالي", bodyFont, Brushes.Black, new PointF(630, startY));
            startY += 20;
            g.DrawLine(Pens.Black, startX, startY, 750, startY);
            startY += 10;

            decimal grandTotal = 0;
            foreach (var item in _currentInvoiceItems)
            {
                decimal itemTotal = item.Quantity * item.PurchasePrice;
                grandTotal += itemTotal;

                g.DrawString(item.ProductName, regularFont, Brushes.Black, new PointF(startX, startY));
                g.DrawString(item.Quantity.ToString(), regularFont, Brushes.Black, new PointF(350, startY));
                g.DrawString(item.PurchasePrice.ToString("N2"), regularFont, Brushes.Black, new PointF(480, startY));
                g.DrawString(itemTotal.ToString("N2"), regularFont, Brushes.Black, new PointF(630, startY));

                startY += 25;
            }

            g.DrawLine(Pens.Black, startX, startY, 750, startY);
            startY += 15;

            g.DrawString($"إجمالي الفاتورة الكلي: {grandTotal:N2} ريال", headerFont, Brushes.DarkGreen, new PointF(startX, startY));
        }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class RestockHeaderDto
    {
        public int Id { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime RestockDate { get; set; }
    }

    public class RestockDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
    }

    public class CreateRestockDto
    {
        public string SupplierName { get; set; } = string.Empty;
        public List<RestockDetailDto> Items { get; set; } = new();
    }
}
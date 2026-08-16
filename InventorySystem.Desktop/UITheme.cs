using System.Drawing;

namespace InventorySystem.Desktop;

public static class UITheme
{
    // ألوان الشاشة النموذجية المأخوذة من صورتك
    public static readonly Color AppBackground = Color.FromArgb(243, 245, 249);      // #F3F5F9 خلفية رئيسية
    public static readonly Color CardBackground = Color.FromArgb(255, 255, 255);     // #FFFFFF خلفية الكروت واللوحات
    public static readonly Color SidebarBackground = Color.FromArgb(248, 250, 252);  // #F8FAFC القائمة الجانبية

    // ألوان التميز والتفاعل
    public static readonly Color PrimaryBlue = Color.FromArgb(76, 123, 217);        // #4C7BD9 أزرق الفواتير الكبيرة
    public static readonly Color ActiveMenuBlue = Color.FromArgb(122, 192, 232);    // #7AC0E8 أزرق الزر المحدد
    public static readonly Color DarkHeaderCard = Color.FromArgb(30, 41, 59);       // #1E293B بطاقة الإجمالي المتميزة

    // ألوان النصوص
    public static readonly Color TextDark = Color.FromArgb(30, 41, 59);             // #1E293B النص الأساسي
    public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);         // #64748B النص الثانوي/العناوين الفرعية
    public static readonly Color SuccessGreen = Color.FromArgb(16, 185, 129);       // #10B981 الأخضر للتنبيهات والنسب الإيجابية
}
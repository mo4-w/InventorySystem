namespace InventorySystem.Desktop;

public static class UserSession
{
    public static int UserId { get; set; }
    public static string FullName { get; set; } = string.Empty;
    public static string Username { get; set; } = string.Empty;
    public static string Role { get; set; } = string.Empty;

    public static bool IsLoggedIn => UserId > 0;

    public static void Clear()
    {
        UserId = 0;
        FullName = string.Empty;
        Username = string.Empty;
        Role = string.Empty;
    }
}
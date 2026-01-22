namespace BangHangAPI.Data
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        // 1 user co nhiu order
        public List<Order> Orders { get; set; } = new();
    }
}


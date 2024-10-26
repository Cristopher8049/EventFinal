namespace EventManagement.DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? ProfilePic { get; set; }

        public string? Socials { get; set; }

        public int RoleId { get; set; }

        public string? RolName { get; set; }
    }
}

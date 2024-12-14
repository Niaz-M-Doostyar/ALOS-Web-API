namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

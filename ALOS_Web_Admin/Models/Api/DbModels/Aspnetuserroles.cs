namespace ALOS_Web_Admin.Models.Api.DbModels
{
    public partial class Aspnetuserroles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual Aspnetroles Role { get; set; }
        public virtual Aspnetusers User { get; set; }
    }
}

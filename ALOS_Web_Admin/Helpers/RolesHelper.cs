namespace ALOS_Web_Admin.Helpers
{
    public class RolesHelper
    {
        public static string GetRoleName(int roleId)
        {
            if (roleId.Equals(1))
                return Roles.Admin.ToString();
            if (roleId.Equals(2))
                return Roles.Subadmin.ToString();
            if (roleId.Equals(3))
                return Roles.Employee.ToString();
          return Roles.Client.ToString();
        }
    }
    public enum Roles
    {
        Admin = 1,
        Subadmin = 2,
        Employee = 3,
        Client = 4
    }
}
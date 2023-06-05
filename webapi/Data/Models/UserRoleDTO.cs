namespace webapi.Data.Models
{
    public class UserRoleDTO
    {
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public int PersonId { get; set; }
        public int PersonRoleId { get; set; }
    }
}

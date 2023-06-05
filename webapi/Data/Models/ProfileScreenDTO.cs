namespace webapi.Data.Models
{
    public class ProfileScreenDTO
    {
        public string Surname { get; set; } 
        public string MiddleName { get; set; }  
        public string FirstName { get; set; }
        public string About { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ProfilePicPath { get; set; }
    }
}

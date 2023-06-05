namespace webapi.Data.Models
{
    public class RegistrationDTO
    {
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? Telephone { get; set; }
        public int GenderID { get; set; }
        public string? Email { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string ProfilePicPath { get; set; }
        public string? RegisterPara { get; set; }
        public string? Grandparents { get; set; }
        public string? Parents { get; set; }
        public string? GreatGrandparents { get; set; }
        public int ClanHouseID { get; set; }




    }
}

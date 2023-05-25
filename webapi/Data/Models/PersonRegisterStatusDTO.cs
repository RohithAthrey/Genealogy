namespace webapi.Data.Models;

public class PersonRegisterStatusDTO
{
    public int RequestTypeId { get; set; }
    public ICollection<PersonStatus> PersonStatuses { get; set; }
}

public class PersonStatus
{
    public int PersonId { get; set; }
    public string FullName { get; set; }
    public string ProfilePicPath { get; set; }
    public string ClanName { get; set; }
    public int PersonClanRequestId { get; set; }
}

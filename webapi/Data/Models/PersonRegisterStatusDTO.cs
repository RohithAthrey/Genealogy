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
    public string ClanHouseName { get; set; }
    public string RegisterPara { get; set; }
    public string Grandparents { get; set; }
    public string Parents { get; set; }
    public string GreatGrandparents { get; set; }
    public int PersonClanHouseRequestId { get; set; }
}

namespace webapi.Data.Models
{
    public class UpdatedRequestDTO
    {
        public int PersonClanHouseRequestId { get; set; }
        public int PersonId { get; set; }
        public int RequestTypeId { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}

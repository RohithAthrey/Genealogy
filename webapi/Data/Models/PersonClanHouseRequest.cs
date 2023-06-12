using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models;

public class PersonClanHouseRequest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PersonClanHouseRequestID { get; set; }
    [ForeignKey("Person")]
    [Required]
    public int PersonID { get; set; }
    [ForeignKey("ClanHouse")]
    [Required]
    public int ClanHouseID { get; set; }
    [ForeignKey("RequestType")]
    [Required]
    public int RequestTypeID { get; set; }
    [Required]
    public DateTime LastUpdatedDate { get; set; }
    [Required]
    public string LastUpdatedBy { get; set; }
    public Person Person { get; set; }
    public ClanHouse ClanHouse { get; set; }
    public RequestType RequestType { get; set; }
}

//public class PersonClanHouseRequest
//{
//    [Key]
//    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//    public int PersonClanHouseRequestID { get; set; }
//    [ForeignKey("Person")]
//    [Required]
//    public int PersonID { get; set; }
//    [ForeignKey("ClanHouse")]
//    [Required]
//    public int ClanHouseID { get; set; }
//    [ForeignKey("RequestType")]
//    [Required]
//    public int RequestTypeID { get; set; }
//    [Required]
//    public DateTime LastUpdatedDate { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(128)")]
//    public string LastUpdatedBy { get; set; }
//    public Person Person { get; set; }
//    public ClanHouse ClanHouse { get; set; }
//    public RequestType RequestType { get; set; }
//}

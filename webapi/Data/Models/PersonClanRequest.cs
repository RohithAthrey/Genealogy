using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models;

public class PersonClanRequest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PersonClanRequestID { get; set; }
    [ForeignKey("Person")]
    [Required]
    public int PersonID { get; set; }
    [ForeignKey("Clan")]
    [Required]
    public int ClanID { get; set; }
    [ForeignKey("RequestType")]
    [Required]
    public int RequestTypeID { get; set; }
    [Required]
    public DateTime LastUpdatedDate { get; set; }
    [Required]
    [Column(TypeName = "varchar(128)")]
    public string LastUpdatedBy { get; set; }
    public Person Person { get; set; }
    public Clan Clan { get; set; }
    public RequestType RequestType { get; set; }
}

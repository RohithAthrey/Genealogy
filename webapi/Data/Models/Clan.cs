using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models;

public class Clan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClanID { get; set; }
    [Required]
    [Column(TypeName = "varchar(32)")]
    public string Name { get; set; }
    [Required]
    [Column(TypeName = "varchar(32)")]
    public string Symbol { get; set; }
    [Required]
    [Column(TypeName = "varchar(32)")]
    public string SubTotem { get; set; }
}

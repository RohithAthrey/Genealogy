using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models;

public class Gender
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GenderID { get; set; }
    [Required]
    public string GenderCode { get; set; }
    [Required]
    public string GenderValue { get; set; }
}

//public class Gender
//{
//    [Key]
//    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//    public int GenderID { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(16)")]
//    public string GenderCode { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(32)")]
//    public string GenderValue { get; set; }
//}

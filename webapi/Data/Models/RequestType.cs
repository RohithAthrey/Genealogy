using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models;

public class RequestType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestTypeID { get; set; }
    [Required]
    [Column(TypeName = "varchar(16)")]
    public string RequestTypeCode { get; set; }
    [Required]
    [Column(TypeName = "varchar(32)")]
    public string RequestTypeValue { get; set; }
}

//public class RequestType
//{
//    [Key]
//    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//    public int RequestTypeID { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(16)")]
//    public string RequestTypeCode { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(32)")]
//    public string RequestTypeValue { get; set; }
//}

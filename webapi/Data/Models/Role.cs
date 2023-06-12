using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models;

public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleID { get; set; }
    [Required]
    public string RoleName { get; set; }
    [Required]
    public string RoleDesc { get; set; }
    public ICollection<PersonRole> PersonRoles { get; set; }
}

//public class Role
//{
//    [Key]
//    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//    public int RoleID { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(32)")]
//    public string RoleName { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(64)")]
//    public string RoleDesc { get; set; }
//    public ICollection<PersonRole> PersonRoles { get; set; }
//}

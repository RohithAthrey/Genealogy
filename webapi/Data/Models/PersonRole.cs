using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models;

public class PersonRole
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PersonRoleID { get; set; }
    [ForeignKey("Person")]
    [Required]
    public int PersonID { get; set; }
    [ForeignKey("Role")]
    [Required]
    public int RoleID { get; set; }
    [Required]
    public bool IsActive { get; set; }
    [Required]
    public DateTime LastUpdatedDate { get; set; }
    [Required]
    public string LastUpdatedBy { get; set; }
    public Person Person { get; set; }
    public Role Role { get; set; }


}

//public class PersonRole
//{
//    [Key]
//    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//    public int PersonRoleID { get; set; }
//    [ForeignKey("Person")]
//    [Required]
//    public int PersonID { get; set; }
//    [ForeignKey("Role")]
//    [Required]
//    public int RoleID { get; set; }
//    [Required]
//    public bool IsActive { get; set; }
//    [Required]
//    public DateTime LastUpdatedDate { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(128)")]
//    public string LastUpdatedBy { get; set; }
//    public Person Person { get; set; }
//    public Role Role { get; set; }


//}

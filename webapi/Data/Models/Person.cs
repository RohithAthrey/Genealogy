using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models;

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PersonID { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string MiddleName { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string BirthDate { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
    public string? Telephone { get; set; }
    [ForeignKey("Gender")]
    [Required]
    public int GenderID { get; set; }
    [ForeignKey("ClanHouse")]
    [Required]
    public int ClanHouseID { get; set; }
    public string? Email { get; set; }
    [Required]
    public string LoginId { get; set; }
    public string? Password { get; set; }
    public string? ProfilePicPath { get; set; }
    [Required]
    public bool IsActive { get; set; }
    [Required]
    public bool IsUser { get; set; }
    [Required]
    public DateTime LastUpdatedDate { get; set; }
    [Required]
    public string LastUpdatedBy { get; set; }
    public string? RegisterPara { get; set; }
    public string? Grandparents { get; set; }
    public string? Parents { get; set; }
    public string? GreatGrandparents { get; set; }
    public Gender Gender { get; set; }
    public ICollection<PersonClanHouseRequest> PersonClanHouseRequests { get; set; }
    public ICollection<PersonRole> PersonRoles { get; set; }
}
//public class Person
//{
//    [Key]
//    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//    public int PersonID { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(32)")]
//    public string LastName { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(32)")]
//    public string MiddleName { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(32)")]
//    public string FirstName { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(16)")]
//    public string BirthDate { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(64)")]
//    public string Address { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(32)")]
//    public string City { get; set; }
//    [Column(TypeName = "varchar(16)")]
//    public string? Telephone { get; set; }
//    [ForeignKey("Gender")]
//    [Required]
//    public int GenderID { get; set; }
//    [ForeignKey("ClanHouse")]
//    [Required]
//    public int ClanHouseID { get; set; }
//    [Column(TypeName = "varchar(64)")]
//    public string? Email { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(64)")]
//    public string LoginId { get; set; }
//    [Column(TypeName = "varchar(128)")]
//    public string? Password { get; set; }
//    [Column(TypeName = "varchar(128)")]
//    public string? ProfilePicPath { get; set; }

//    [Required]
//    public bool IsActive { get; set; }
//    [Required]
//    public bool IsUser { get; set; }
//    [Required]
//    public DateTime LastUpdatedDate { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(128)")]
//    public string LastUpdatedBy { get; set; }
//    [Column(TypeName = "varchar(MAX)")]
//    public string? RegisterPara { get; set; }
//    [Column(TypeName = "varchar(128)")]
//    public string? Grandparents { get; set; }
//    [Column(TypeName = "varchar(128)")]
//    public string? Parents { get; set; }
//    [Column(TypeName = "varchar(128)")]
//    public string? GreatGrandparents { get; set; }
//    public Gender Gender { get; set; }
//    public ICollection<PersonClanHouseRequest> PersonClanHouseRequests { get; set; }
//    public ICollection<PersonRole> PersonRoles { get; set; }
//}

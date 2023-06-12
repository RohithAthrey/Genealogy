using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Models;

    public class ClanHouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClanHouseID { get; set; }
        [Required]
        public string ClanHouseName { get; set;}
        [ForeignKey("Clan")]
        [Required]
        public int ClanID { get; set; }
        public Clan Clan { get; set; }
    }

//public class ClanHouse
//{
//    [Key]
//    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//    public int ClanHouseID { get; set; }
//    [Required]
//    [Column(TypeName = "varchar(32)")]
//    public string ClanHouseName { get; set; }
//    [ForeignKey("Clan")]
//    [Required]
//    public int ClanID { get; set; }
//    public Clan Clan { get; set; }
//}

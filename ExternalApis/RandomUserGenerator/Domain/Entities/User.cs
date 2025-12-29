using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobRunner.ExternalApis.RandomUserGenerator.Domain.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("seed")]
        public string Seed { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("gender")]
        public int Gender { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("phone")]
        public string Phone { get; set; }

        [Required]
        [Column("naturality")]
        public string Naturality { get; set; }

        [Required]
        [Column("birthday")]
        public DateOnly Birthday { get; set; }

        [Required]
        [ForeignKey("UserLocation")]
        [Column("idlocation")]
        public int IdLocation { get; set; }

        public virtual UserLocation UserLocation { get; set; }
    }
}

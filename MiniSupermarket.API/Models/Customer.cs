using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // IDENTITY(1,1)
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string? Address { get; set; }   // Cho phép NULL

        public int RewardPoints { get; set; } = 0;

        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string MembershipRank { get; set; } = "Chuẩn";
    }
}
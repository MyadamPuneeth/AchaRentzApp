
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL.Models
{
    public class RentalDetails
    {
        [Key]
        public int RentalId { get; set; }
        public string? Location { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public double RentalDuration { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("CarDetails")]
        public int CarId { get; set; }
        public virtual CarDetails CarDetails { get; set; }
    }
}

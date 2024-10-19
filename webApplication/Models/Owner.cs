using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApplication.Models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("CarDetail")]
        public int CarId { get; set; }
        public CarDetails CarDetail { get; set; }
    }
}
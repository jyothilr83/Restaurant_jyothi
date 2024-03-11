using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpiceNRice.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {//remember this already in a relationship with Orders 
        public int Id { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required, MaxLength(20)]
        public string StatusName { get; set; }
    }
}
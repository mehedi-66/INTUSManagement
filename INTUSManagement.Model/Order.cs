using System.ComponentModel.DataAnnotations;

namespace INTUSManagement.Model
{
    public class Order
    {
        public Order() { 
             this.Windows = new List<Window>();
        }
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string Name {get; set;}

        [Required]
        public string State { get; set;}

        public List<Window> Windows { get; set;}

    }
}
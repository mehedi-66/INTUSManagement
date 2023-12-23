using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTUSManagement.Model
{
    public class Window
    {
        public Window()
        {
            this.SubElements = new List<SubElement>();
        }

        [Key]
        public int WindowId { get; set; }

        [Required]
        public string Name {get; set;}
        [Required]
        public int QuantityOfWindows { get; set;}
        [Required]
        public int TotalSubElements { get; set;}

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set;}

        public List<SubElement> SubElements { get; set; }
    }
}

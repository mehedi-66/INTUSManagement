using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTUSManagement.Model
{
    public class Window
    {
        private int WindowId { get; set; }
        private string Name {get; set;}
        private int QuantityOfWindows { get; set;}

        private int TotalSubElements { get; set;}
        private List<SubElement> SubElements { get; set;}

        [ForeignKey("Order")]
        private int OrderId { get; set;}
    }
}

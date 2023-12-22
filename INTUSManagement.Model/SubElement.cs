using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTUSManagement.Model
{
    public class SubElement
    {
        private int SubElementId { get; set; }
        private string Type { get; set; }
        private float Width { get; set; }
        private float Height { get; set; }

        [ForeignKey("Window")]
        private int WindowId { get; set; }
    }
}

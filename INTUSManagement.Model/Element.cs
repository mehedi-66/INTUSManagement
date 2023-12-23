using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTUSManagement.Model
{
    public class Element
    {
        [Key]
        public int ElementId { get; set; }
        private string Type { get; set; }
        private float Width { get; set; }
        private float Height { get; set; }
    }
}

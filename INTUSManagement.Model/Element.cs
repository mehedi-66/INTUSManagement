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
        [Required]
        public string Type { get; set; }
        [Required]
        public float Width { get; set; }
        [Required]
        public float Height { get; set; }
    }
}

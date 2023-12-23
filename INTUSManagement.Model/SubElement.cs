using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTUSManagement.Model
{
    public class SubElement
    {

        [Key]
        public int SubElementId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public float Width { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        [ForeignKey("Window")]
        public int WindowId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ImagePost
    {
        [Key]
        public int idImage { get; set; }
        [Required(ErrorMessage ="Path is required")]
        public string path { get; set; }
        public bool state { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Dtos
{
    public class TypeOfNotificationDto
    {
        [Key]
        public int idType { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "The message is required")]
        [StringLength(256, ErrorMessage = "Maximum characters is 100")]
        public string message { get; set; }
        
    }
}

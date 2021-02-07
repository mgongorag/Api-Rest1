using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Dtos
{
    public class PostUserDto
    {
        [Key]
        public int idUSer { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
    }
}

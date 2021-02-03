using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Dtos
{
    public class UserProfileDto
    {
        [Key]
        public int idUSer { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthday { get; set; }
        public Gender gender { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime lastSession { get; set; }
        public ICollection<Post> post { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Post
    {
        [Key]
        public int idPost { get; set; }
        [StringLength(2000, ErrorMessage = "Only 2000 characters allowed")]
        public string description { get; set; }
        public DateTime date { get; set; }
        public int idUser { get; set; }
        [ForeignKey("idUser")]
        public User user { get; set; }
        public bool state { get; set; }
        public int idTypePost { get; set; }
        [ForeignKey("idTypePost")]
        public TypeOfPost typeOfPost { get; set; }

        public Post()
        {
            this.date = DateTime.Now;
            this.state = true;
        }

    }
}

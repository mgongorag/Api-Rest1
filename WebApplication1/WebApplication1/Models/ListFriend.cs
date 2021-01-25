using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ListFriend
    {
        public int idUser { get; set; }
        public int idFriend { get; set; }
        public DateTime dateAdded { get; set; }
        public bool state { get; set; }
        [ForeignKey("idUser")]
        public User user { get; set; }
        [ForeignKey("idFriend")]
        public User friend { get; set; }
    }
}

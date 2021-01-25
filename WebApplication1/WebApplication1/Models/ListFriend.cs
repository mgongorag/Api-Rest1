using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ListFriend
    {
        [Key, Column(Order = 1)]
        public int idUser { get; set; }
        [Key, Column(Order = 2)]
        public int idFriend { get; set; }
        public DateTime dateAdded { get; set; }
        public bool state { get; set; }
        public User user { get; set; }
        public User friend { get; set; }
    }
}

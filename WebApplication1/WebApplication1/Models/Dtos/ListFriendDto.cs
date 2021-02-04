using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Dtos
{
    public class ListFriendDto
    {
        [Required(ErrorMessage = "Id user is required")]
        [Key, Column(Order = 1)]
        public int idUser { get; set; }
        [Required(ErrorMessage = "Id friend is required")]
        [Key, Column(Order = 2)]
        public int idFriend { get; set; }
       
    }
}

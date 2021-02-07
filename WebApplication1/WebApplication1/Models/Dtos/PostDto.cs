using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Dtos
{
    public class PostDto
    {
        [Key]
        public int idPost { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public TypeOfPost typeOfPost { get; set; }
        public List<ImagePostDto> images { get; set; }
        public PostUserDto user { get; set; }

    }
}

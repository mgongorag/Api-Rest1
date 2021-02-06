using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Dtos
{
    public class ImagePostDto
    {

        [Key]
        public int idImage { get; set; }
        public string path { get; set; }
        public bool state { get; set; }

        public int idPost { get; set; }


        public ImagePostDto()
        {
            this.state = true;
        }
    }
}

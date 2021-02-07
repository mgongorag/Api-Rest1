using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Dtos
{
    public class CreatePostDto
    {
        public string description { get; set; }
        public DateTime date { get; set; }
        public int idUser { get; set; }
        public bool state { get; set; }
        [ForeignKey("idTypePost")]
        public int idTypePost { get; set; }
        public ICollection <IFormFile> images { get; set; }

        public CreatePostDto()
        {
            this.date = DateTime.Now.Date;
            this.state = true;
        }


    }
}

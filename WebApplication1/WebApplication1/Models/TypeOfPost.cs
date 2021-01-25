using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TypeOfPost
    {
        [Key]
        public int idTypeOfPost { get; set; }
        public string typePost { get; set; }
    }
}

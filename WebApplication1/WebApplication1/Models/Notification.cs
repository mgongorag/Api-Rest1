using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Notification
    {
        [Key]
        public int idNotification { get; set; }
        [ForeignKey("idUser")]
        public string idUser { get; set; }
        [Required (ErrorMessage = "Description is required")]
        [StringLength(250, ErrorMessage = "Only 2000 characters allowed")]
        public string description { get; set; }
        public bool isRead { get; set; }
        public DateTime date { get; set; }
        public int idType { get; set; }
        [ForeignKey("idType")]
        public TypeOfNotification typeOfNotification { get; set; }
        public int idPost { get; set; }
        [ForeignKey("idPost")]
        public Post post { get; set; }

    }
}

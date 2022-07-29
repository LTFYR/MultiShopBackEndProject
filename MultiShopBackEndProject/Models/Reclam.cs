using Microsoft.AspNetCore.Http;
using MultiShopBackEndProject.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShopBackEndProject.Models
{
    public class Reclam:BaseEntity
    {
        public string Offer { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Foto { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using MultiShopBackEndProject.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShopBackEndProject.Models
{
    public class Slider:BaseEntity
    {
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public byte Order { get; set; }
        [NotMapped]
        public IFormFile Foto { get; set; }
    }
}

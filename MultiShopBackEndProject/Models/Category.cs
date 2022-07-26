using Microsoft.AspNetCore.Http;
using MultiShopBackEndProject.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShopBackEndProject.Models
{
    public class Category:BaseEntity
    {
        [Required,StringLength(maximumLength:20)]
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
       public  List<Clothe> Clothes { get; set; }
        [NotMapped]
        public IFormFile Foto { get; set; }

    }
}

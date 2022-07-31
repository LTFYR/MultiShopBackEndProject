using MultiShopBackEndProject.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MultiShopBackEndProject.Models
{
    public class Contact:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}

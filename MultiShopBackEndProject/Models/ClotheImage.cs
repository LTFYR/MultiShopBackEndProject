using MultiShopBackEndProject.Models.Base;

namespace MultiShopBackEndProject.Models
{
    public class ClotheImage:BaseEntity
    {
        public string Image { get; set; }
        public string Alt { get; set; }
        public string ClotheId { get; set; }
        public bool IsMain { get; set; }
        public Clothe Clothe { get; set; }
    }
}

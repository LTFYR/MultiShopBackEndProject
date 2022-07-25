using MultiShopBackEndProject.Models.Base;

namespace MultiShopBackEndProject.Models
{
    public class Setting : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

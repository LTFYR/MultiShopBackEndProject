using MultiShopBackEndProject.Models;
using System.Collections.Generic;

namespace MultiShopBackEndProject.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Clothe> Clothes { get; set; }
        public List<Category> Categories { get; set; }
        public List<Reclam> Reclams { get; set; }
    }
}

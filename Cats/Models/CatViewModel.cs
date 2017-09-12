using System.ComponentModel;

namespace ReturnOnIntelligenceTask.Models
{
    public class CatViewModel
    {
        [DisplayName("Cat's category")]
        public string SelectedCategory { get; set; }

        public string[] CategoriesNames { get; set; }
    }
}
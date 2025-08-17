using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string FeaturedImage { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public bool IsActive { get; set; }   
    }
}

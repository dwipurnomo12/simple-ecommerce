using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models
{
    public class ProductImage
    {
        [Key]
        public string Id { get; set; }

        public string Image { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}

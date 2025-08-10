using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Sku { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
   
        public int Stock { get; set; } = 0;

        [Required]
        public string FeaturedImage { get; set; }

        public bool IsAvailable { get; set; } = true;

        // relationship one to one to category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // relationship one to many to product images
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ürün İsmi Gerekiyor")]
        public string? ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fiyat Gerekiyor")]
        public decimal Price { get; set; }
    }
}
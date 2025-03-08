using App.Data.Entities;

namespace SimoshStoreAPI;

public class ProductDetailsViewModel
{
    public ProductEntity Product { get; set; } = null!;
    public int Star { get; set; } = 0;
    public List<ProductEntity> RelatedProducts { get; set; } = new List<ProductEntity>();
    public List<ProductEntity> SimilarProducts { get; set; } = new List<ProductEntity>();
    public UserEntity User { get; set; } = null!;
    public decimal DiscountedPrice { get; set; } = 0;
}

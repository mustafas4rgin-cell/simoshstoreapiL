using App.Data.Entities;

namespace SimoshStoreAPI;

public class SaerchBoxViewModel
{
    public List<CategoryEntity> Categories { get; set; }
    public List<ProductEntity> FeaturedProducts { get; set; }
    public List<int> SelectedCategoryIds { get; set; }
}

using App.Data.Entities;

namespace SimoshStoreAPI;

internal class ListProductsViewModel
    {
        public List<ProductEntity> productEntities { get; set; } = new List<ProductEntity>();
        public List<ProductCommentEntity> comments { get; set; } = new List<ProductCommentEntity>();
        public int CurrentPage { get; set; } = 1;
        public int TotalProductCount { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public List<int> SelectedCategoryIds { get; set; } = new List<int>();
        public decimal PriceMin { get; set; } = 0;
        public decimal PriceMax { get; set; }  = 999999;
        public string DzSearch { get; set; } = "";
    }

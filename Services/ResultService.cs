using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using SimoshStore;

namespace SimoshStoreAPI;

public class ResultService : IResultService
{
    private readonly IDataRepository _dataRepository;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public ResultService(IProductService productService, ICategoryService categoryService, IDataRepository dataRepository)
    {
        _productService = productService;
        _categoryService = categoryService;
        _dataRepository = dataRepository;
    }

    public int GetOrderCount()
    {
        var ordersCount = _dataRepository.GetAll<OrderEntity>().Count();
        if (ordersCount == 0)
        {
            return 0;
        }
        return ordersCount;
    }
    public int GetProductCommentCount()
    {
        var commentsCount = _dataRepository.GetAll<ProductCommentEntity>().Count();
        if (commentsCount == 0)
        {
            return 0;
        }
        return commentsCount;
    }
    public int GetBlogCommentCount()
    {
        var commentsCount = _dataRepository.GetAll<BlogCommentEntity>().Count();
        if (commentsCount == 0)
        {
            return 0;
        }
        return commentsCount;
    }
}
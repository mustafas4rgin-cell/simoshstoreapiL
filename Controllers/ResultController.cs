using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ResultController(IProductService productService, ICategoryService categoryService, IResultService resultService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _resultService = resultService;
        }
        [HttpGet("/api/result-orders")]
        public IActionResult GetOrdersResult()
        {
            var result = _resultService.GetOrderCount();
            return Ok(result);
        }
        [HttpGet("/api/result-product-comments")]
        public IActionResult GetProductCommentsResult()
        {
            var result = _resultService.GetProductCommentCount();
            return Ok(result);
        }
        [HttpGet("/api/result-blog-comments")]
        public IActionResult GetBlogCommentsResult()
        {
            var result = _resultService.GetBlogCommentCount();
            return Ok(result);
        }
        [HttpGet("/api/result-comments")]
        public IActionResult GetCommentsResult()
        {
            var productComments = _resultService.GetProductCommentCount();
            var blogComments = _resultService.GetBlogCommentCount();
            return Ok(productComments + blogComments);
        }
        [HttpGet("/api/search-box")]
        public async Task<IActionResult> GetSearchBoxResult()
        {
            var products = await _productService.GetProductsAsync();
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(new SaerchBoxViewModel
            {
                FeaturedProducts = products.ToList(),
                Categories = categories.ToList()
            });
        }
    }
}

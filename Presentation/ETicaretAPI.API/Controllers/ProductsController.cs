using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository,IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async void Get()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product1", Price = 100, CreateDate = DateTime.Now, Stock = 10 },
                new() { Id = Guid.NewGuid(), Name = "Product2", Price = 200, CreateDate = DateTime.Now, Stock = 20 },
                new() { Id = Guid.NewGuid(), Name = "Product3", Price = 300, CreateDate = DateTime.Now, Stock = 30 },
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}

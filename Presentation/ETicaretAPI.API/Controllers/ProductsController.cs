using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
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
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository,IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            var customerId = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Deneme" });

            _orderWriteRepository.AddAsync(new() { Description = "deneme", Address = "İstanbul", CustomerId = customerId });
            _orderWriteRepository.AddAsync(new() { Description = "deneme2", Address = "İstanbul2", CustomerId = customerId });
            _orderWriteRepository.SaveAsync();
        }
        
    }
}

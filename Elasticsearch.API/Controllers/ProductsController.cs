using Elasticsearch.API.Entities;
using Elasticsearch.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Elasticsearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _genericRepository;
        public ProductsController(IGenericRepository<Product> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        [HttpGet("getAll")]
        public List<Product> GetAll()
        {            
            var response =  _genericRepository.GetAll(true).ToList();
            return response;
        }
    }
}

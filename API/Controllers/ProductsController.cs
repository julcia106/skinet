using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task <ActionResult<List<Product>>> GetProducts() //execute a 'select' query on db, then return results and store in var products
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products); //restarts API server, and make sure that this method is working
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
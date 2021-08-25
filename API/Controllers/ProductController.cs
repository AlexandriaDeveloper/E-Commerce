using System.Threading.Tasks;
using Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController :ControllerBase
    {
        private readonly StoreContext _ctx;

        public ProductController(StoreContext ctx)
        {
            _ctx = ctx;


        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
           return Ok( await _ctx.Products.ToListAsync());

        }

  [HttpGet("{id}")]             
   public async Task<ActionResult> Get(int id )
        {
           return Ok( await _ctx.Products.FindAsync(id));

        }
    }
}
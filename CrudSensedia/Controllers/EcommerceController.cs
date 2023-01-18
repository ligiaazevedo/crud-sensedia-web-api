using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudSensedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        private static List<Ecommerce> products = new List<Ecommerce>
            {
                new Ecommerce {
                    Id = 1,
                    Product = "T-shirt",
                    Price = 5.50
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Ecommerce>>> Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return BadRequest("Product not found.");
            }
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<List<Ecommerce>>> AddProduct(Ecommerce product)
        {
            products.Add(product);
            return Ok(products);
        }

        [HttpPut]
        public async Task<ActionResult<List<Ecommerce>>> UpdateProduct(Ecommerce request)
        {
            var product = products.Find(p => p.Id == request.Id);
            if (product == null)
            {
                return BadRequest("Product not found.");
            }

            product.Product = request.Product;
            product.Price = request.Price;
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Ecommerce>>> Delete(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
                return BadRequest("Product not found.");

            products.Remove(product);
            return Ok(products);
        }

    }
}


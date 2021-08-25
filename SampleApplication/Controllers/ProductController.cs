using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Services.Products;

namespace SampleApplication.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _mediator.Send(new GetProductsRequest());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Models.Product product)
        {
            var newProduct = await _mediator.Send(new AddProductRequest(product));
            return CreatedAtRoute("GetProductById", new { id = newProduct.Id, }, product);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdRequest(id));
            return Ok(product);
        }
    }
}

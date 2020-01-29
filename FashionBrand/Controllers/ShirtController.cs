using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionBrand.Models;
using FashionBrand.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FashionBrand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShirtController : ControllerBase
    {
        private readonly ShirtService _shirt;

        public ShirtController(ShirtService shirt)
        {
            _shirt = shirt;
        }

        [HttpGet]
        public ActionResult<List<Shirt>> Get() =>
            _shirt.Get();

        [HttpGet("{id:length(24)}", Name ="GetShirt")]
        public ActionResult<Shirt> Get(string id)
        {
            var shrt = _shirt.Get(id);

            if(shrt == null)
            {
                return NotFound();
            }

            return shrt;
        }

        [HttpPost]
        public ActionResult<Shirt> Create(Shirt shirt)
        {
            _shirt.Create(shirt);

            return CreatedAtRoute("GetShirt", new { id = shirt.Id.ToString() }, shirt);
        }

        [HttpPut("{id:length(24)}")]
      //  [ProducesResponseType(StatusCode.Status200OK)]
        public IActionResult Update(string id, Shirt shirt)
        {
            var shrt = _shirt.Get(id);
            
            if(shrt == null)
            {
                return NotFound();
            }

            _shirt.Update(id, shirt);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var shirt = _shirt.Get(id);
            if(shirt == null)
            {
                return NotFound();
            }

            _shirt.Remove(shirt.Id);

            return NoContent();
        }
    }
}

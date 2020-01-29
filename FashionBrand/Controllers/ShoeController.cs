using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionBrand.Services;
using FashionBrand.Models;
using Microsoft.AspNetCore.Mvc;

namespace FashionBrand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        // sa pamamagitan nito ma aaccess mo lahat ng function ni ShoeService class
        private readonly ShoeService _sapatos;

        public ShoeController(ShoeService sapatos)
        {
            _sapatos = sapatos;
        }

        [HttpGet]
        public ActionResult<List<Shoes>> Get() =>
            _sapatos.Get();

        [HttpGet("{id:length(24)}", Name = "GetShoes")]
        public ActionResult<Shoes> Get(string id)
        {
            var shoe = _sapatos.Get(id);

            if(shoe == null)
            {
                return NotFound();
            }

            return shoe;
        }

        [HttpPost]
        public ActionResult<Shoes> Create(Shoes shoe)
        {
            _sapatos.Gawa(shoe);

            return CreatedAtRoute("GetShoes", new { id = shoe.Id.ToString() }, shoe);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Shoes shoeIn)
        {
            var shoe = _sapatos.Get(id);

            if(shoe == null)
            {
                return NotFound();
            }

            _sapatos.Updating(id, shoeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var sapatos = _sapatos.Get(id);

            if(sapatos == null)
            {
                return NotFound();
            }

            _sapatos.Burahin(sapatos.Id);

            return NoContent();
        }

    }
}

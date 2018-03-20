using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Api_Venda.Models;

namespace Api_Venda.Controllers
{
    [Route("api/[controller]")]
    public class DetalhesPedController : Controller
    {
        private readonly VendaContext _context;
        public DetalhesPedController(VendaContext context)
        {
            _context = context;

            if (_context.Pedidos.Count() == 0)
            {
                _context.DetalhesPeds.Add(new DetalhesPed { IdProd = 1, Preco = 6.5M, Qtde = 200 });
                _context.SaveChanges();
            }
        }

        [HttpGet("{id}", Name = "Getped")]
        public IActionResult GetById(long id)
        {
            var dped = _context.DetalhesPeds.FirstOrDefault(dp => dp.Id == id);
            if (dped == null)
            {
                return NotFound();
            }
            return new ObjectResult(dped);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DetalhesPed dped)
        {
            if (dped == null)
            {
                return BadRequest();
            }

            _context.DetalhesPeds.Add(dped);
            _context.SaveChanges();

            return CreatedAtRoute("GetDetalhesPed", new { id = dped.Id }, dped);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] DetalhesPed dped)
        {
            if (dped == null || dped.Id != id)
            {
                return BadRequest();
            }

            var Venda = _context.DetalhesPeds.FirstOrDefault(dp => dp.Id == id);
            if (Venda == null)
            {
                return NotFound();
            }

            Venda.IdProd = dped.IdProd;
            Venda.Preco = dped.Preco;
            Venda.Qtde = dped.Qtde;

            _context.DetalhesPeds.Update(Venda);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Venda = _context.DetalhesPeds.FirstOrDefault(d => d.Id == id);
            if (Venda == null)
            {
                return NotFound();
            }

            _context.DetalhesPeds.Remove(Venda);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
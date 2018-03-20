using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Api_Venda.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Venda.Controllers
{

    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly VendaContext _context;
        public PedidoController(VendaContext context)
        {
            _context = context;

            if (_context.Pedidos.Count() == 0)
            {
                _context.Pedidos.Add(new Pedido { IdCli = 1 });
                _context.SaveChanges();
            }
        }

        [HttpGet("{id}", Name = "Getped")]
        public IActionResult GetById(long id)
        {
            var ped = _context.Pedidos.FirstOrDefault(d => d.Id == id);
            if (ped == null)
            {
                return NotFound();
            }
            return new ObjectResult(ped);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pedido ped)
        {
            if (ped == null)
            {
                return BadRequest();
            }

            _context.Pedidos.Add(ped);
            _context.SaveChanges();

            return CreatedAtRoute("GetPedido", new { id = ped.Id }, ped);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Pedido ped)
        {
            if (ped == null || ped.Id != id)
            {
                return BadRequest();
            }

            var Venda = _context.Pedidos.FirstOrDefault(d => d.Id == id);
            if (Venda == null)
            {
                return NotFound();
            }

            Venda.Data = ped.Data;
            Venda.IdCli = ped.IdCli;

            _context.Pedidos.Update(Venda);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Venda = _context.Pedidos.FirstOrDefault(d => d.Id == id);
            if (Venda == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(Venda);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

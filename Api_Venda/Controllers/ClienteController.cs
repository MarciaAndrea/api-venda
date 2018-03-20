using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Api_Venda.Models;


namespace Api_Venda.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly VendaContext _context;
        public ClienteController(VendaContext context)
        {
            _context = context;

            if (_context.Clientes.Count() == 0)
            {
                _context.Clientes.Add(new Cliente { Nome = "Ana", Endereco = "Canoa Quebra, s/n Aracati Ce", Email = "Ana@gmail.com" });
                _context.SaveChanges();
            }
        }

        [HttpGet("{id}", Name = "Getcli")]
        public IActionResult GetById(long id)
        {
            var cli = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cli == null)
            {
                return NotFound();
            }
            return new ObjectResult(cli);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cli)
        {
            if (cli == null)
            {
                return BadRequest();
            }

            _context.Clientes.Add(cli);
            _context.SaveChanges();

            return CreatedAtRoute("GetVenda", new { id = cli.Id }, cli);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Cliente cli)
        {
            if (cli == null || cli.Id != id)
            {
                return BadRequest();
            }

            var Venda = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (Venda == null)
            {
                return NotFound();
            }

            Venda.Nome = cli.Nome;
            Venda.Endereco = cli.Endereco;
            Venda.Email = cli.Email;

            _context.Clientes.Update(Venda);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Venda = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (Venda == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(Venda);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

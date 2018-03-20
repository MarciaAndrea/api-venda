using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Api_Venda.Models;

namespace Api_Venda.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly VendaContext _context;
        public ProdutoController(VendaContext context)
        {
            _context = context;

            if (_context.Produtos.Count() == 0)
            {
                _context.Produtos.Add(new Produto { Nome = "Suco", Preco = 6.5M, Estoque = 100 });
                _context.SaveChanges();
            }
        }

        [HttpGet("{id}", Name = "Getped")]
        public IActionResult GetById(long id)
        {
            var prod = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (prod == null)
            {
                return NotFound();
            }
            return new ObjectResult(prod);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto prod)
        {
            if (prod == null)
            {
                return BadRequest();
            }

            _context.Produtos.Add(prod);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduto", new { id = prod.Id }, prod);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Produto prod)
        {
            if (prod == null || prod.Id != id)
            {
                return BadRequest();
            }

            var Venda = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (Venda == null)
            {
                return NotFound();
            }

            Venda.Nome = prod.Nome;
            Venda.Preco = prod.Preco;
            Venda.Estoque = prod.Estoque;

            _context.Produtos.Update(Venda);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Venda = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (Venda == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(Venda);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

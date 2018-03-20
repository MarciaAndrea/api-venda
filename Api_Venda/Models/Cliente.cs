using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Venda.Models
{

    public class Cliente
    {
        public Cliente()
        {
            Clientes = new Collection<Cliente>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

    }
}

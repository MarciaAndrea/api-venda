using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Venda.Models
{
    public class Pedido
    {
        public Pedido()
        {
            this.Data = DateTime.Now;
            Pedidos = new List<Pedido>();
        }
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public long IdCli { get; set; }

        public virtual Cliente Cli { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

    }
}

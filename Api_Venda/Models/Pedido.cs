using System;
using System.Collections.Generic;

namespace Api_Venda.Models
{
    public class Pedido
    {
        public Pedido()
        {
            this.Data = DateTime.Now;
            DetalhesPedidos = new List<DetalhesPed>();
        }
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public long IdCli { get; set; }

        public virtual Cliente Cli { get; set; }

        public virtual ICollection<DetalhesPed> DetalhesPedidos { get; set; }

    }
}

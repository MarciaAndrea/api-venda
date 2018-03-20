using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Venda.Models
{
    public class DetalhesPed
    {
        public DetalhesPed()
        {
            DetalhesPeds = new List<DetalhesPed>();
        }

        public long Id { get; set; }
        public int IdProd { get; set; }
        public int IdPed { get; set; }
        public decimal Preco { get; set; }
        public int Qtde { get; set; }

        public virtual Produto Prod { get; set; }
        public virtual Produto Ped { get; set; }

        public ICollection<DetalhesPed> DetalhesPeds { get; set; }
    }
}

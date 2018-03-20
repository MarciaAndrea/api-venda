using System.Collections.Generic;

namespace Api_Venda.Models
{
    public class DetalhesPed
    {

        public long Id { get; set; }
        public int IdProd { get; set; }
        public int IdPed { get; set; }
        public decimal Preco { get; set; }
        public int Qtde { get; set; }

        public virtual Produto Prod { get; set; }
        public virtual Pedido Ped { get; set; }
    }
}

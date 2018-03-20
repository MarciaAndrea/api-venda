using System.Collections.Generic;


namespace Api_Venda.Models
{
    public class Produto
    {
        public Produto()
        {
            DetalhesPedidos = new List<DetalhesPed>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public virtual ICollection<DetalhesPed> DetalhesPedidos { get; set; }
    }
}

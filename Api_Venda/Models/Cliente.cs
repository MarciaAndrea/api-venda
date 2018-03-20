using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Api_Venda.Models
{

    public class Cliente
    {
        public Cliente()
        {
            Pedidos = new List<Pedido>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}

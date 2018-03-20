﻿using System.Collections.Generic;


namespace Api_Venda.Models
{
    public class Produto
    {
        public Produto()
        {
            Produtos = new List<Produto>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}

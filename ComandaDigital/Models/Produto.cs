using ComandaDigital.Models.Base;
using System.Collections.Generic;

namespace ComandaDigital.Models
{
    public class Produto : IEntity
    {
        public Produto() { }

        public Produto(string nome, decimal? valorCusto, decimal valorVenda)
        {
            Nome = nome;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }

        public string Nome { get; set; }
        public decimal? ValorCusto { get; set; }
        public decimal ValorVenda { get; set; }
        public virtual int EstabelecimentoId { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual List<ItemPedido> ItensPedidos { get; set; }

        public void Editar(string nome, decimal? valorCusto, decimal valorVenda)
        {
            Nome = nome;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }
    }
}

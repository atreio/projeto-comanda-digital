using ComandaDigital.Models.Base;

namespace ComandaDigital.Models
{
    public class Produto : IEntity
    {
        public Produto() { }

        public Produto(string nome, decimal? valorCusto, decimal? valorVenda)
        {
            Nome = nome;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }

        public string Nome { get; set; }
        public decimal? ValorCusto { get; set; }
        public decimal? ValorVenda { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        public void Editar(string nome, decimal? valorCusto, decimal? valorVenda)
        {
            Nome = nome;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }
    }
}

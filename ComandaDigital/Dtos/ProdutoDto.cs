using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class ProdutoDto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public decimal? ValorCusto { get; set; }
        public decimal ValorVenda { get; set; }
    }

    public class ProdutoListDto
    {
        public List<ProdutoDto> Produtos { get; set; }
    }
}

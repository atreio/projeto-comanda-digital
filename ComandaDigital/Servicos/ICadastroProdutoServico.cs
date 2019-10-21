using ComandaDigital.Dtos;

namespace ComandaDigital.Servicos
{
    public interface ICadastroProdutoServico
    {
        void NovoProduto(ProdutoDto dto);
        void EditarProduto(ProdutoDto dto);
        ProdutoDto BuscaProdutoPorId(int id);
        ProdutoListDto ListarTodosProdutos();
    }
}

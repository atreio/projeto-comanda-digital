using ComandaDigital.Dtos;

namespace ComandaDigital.Servicos
{
    public interface ICadastroItemPedidoServico
    {
        void NovoItemPedido(ItemPedidoDto dto);
        void EditarItemPedido(ItemPedidoDto dto);
        ItemPedidoDto BuscaItemPedidoPorId(int id);
        ItemPedidoListDto ListarTodosItemPedidos();
        void ExcluirItemPedido(ItemPedidoDto dto);
    }
}

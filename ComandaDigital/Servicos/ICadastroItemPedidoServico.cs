using ComandaDigital.Dtos;

namespace ComandaDigital.Servicos
{
    public interface ICadastroItemPedidoServico
    {
        void NovoItemPedido(ItemPedidoDto dto);
        void EditarItemPedido(ItemPedidoDto dto);
        void EditarAndamento(int id);
        void EditarFinalizado(int id);
        ItemPedidoDto BuscaItemPedidoPorId(int id);
        ItemPedidoListDto ListarTodosItemPedidos();
        void ExcluirItemPedido(ItemPedidoDto dto);
    }
}

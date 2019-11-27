using ComandaDigital.Models;
using ComandaDigital.Servicos.Base;

namespace ComandaDigital.Repositorio
{
    public interface IPedidoRepository : ICrudRepository<Pedido>
    {
        Pedido GetPedidoByItemId(int id);
    }
}

using ComandaDigital.Models;
using ComandaDigital.Servicos.Base;

namespace ComandaDigital.Repositorio.Impl
{
    public class ItemPedidoRepository : CrudRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ComandaDigitalContext dbContext) : base(dbContext)
        {
        }
    }
}

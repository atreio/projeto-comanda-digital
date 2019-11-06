using ComandaDigital.Models;
using ComandaDigital.Servicos.Base;

namespace ComandaDigital.Repositorio.Impl
{
    public class PedidoRepository : CrudRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ComandaDigitalContext dbContext) : base(dbContext)
        {

        }
    }
}

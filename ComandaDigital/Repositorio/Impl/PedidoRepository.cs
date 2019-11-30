using ComandaDigital.Models;
using ComandaDigital.Servicos.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ComandaDigital.Repositorio.Impl
{
    public class PedidoRepository : CrudRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ComandaDigitalContext dbContext) : base(dbContext)
        {

        }

        public Pedido GetPedidoByItemId(int id)
        {
            return dbContext.Set<Pedido>()
                .AsTracking()
                .FirstOrDefault(p => p.ItensPedidos.Any(i => i.Id.Equals(id)));
        }
    }
}

using ComandaDigital.Models;
using ComandaDigital.Servicos.Base;

namespace ComandaDigital.Repositorio.Impl
{
    public class MesaRepository : CrudRepository<Mesa>, IMesaRepository
    {
        MesaRepository(ComandaDigitalContext dbContext) : base(dbContext)
        {

        }
    }
}

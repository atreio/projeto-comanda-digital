using ComandaDigital.Models;
using ComandaDigital.Servicos.Base;

namespace ComandaDigital.Repositorio.Impl
{
    public class EstabelecimentoRepository : CrudRepository<Estabelecimento>, IEstabelecimentoRepository
    {
        public EstabelecimentoRepository(ComandaDigitalContext dbContext) : base(dbContext)
        {

        }
    }
}

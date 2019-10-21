using ComandaDigital.Models;
using ComandaDigital.Servicos.Base;

namespace ComandaDigital.Repositorio.Impl
{
    public class ProdutoRepository : CrudRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ComandaDigitalContext dbContext) : base(dbContext)
        {
        }
    }
}

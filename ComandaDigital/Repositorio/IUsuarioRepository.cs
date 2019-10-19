using ComandaDigital.Models;
using ComandaDigital.Servicos.Base;

namespace ComandaDigital.Repositorio
{
    public interface IUsuarioRepository : ICrudRepository<Usuario>
    {
        Usuario GetUsuarioByEmailAndSenha(string username, string senha);
    }
}

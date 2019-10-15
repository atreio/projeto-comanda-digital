using ComandaDigital.Models;
using ComandaDigital.Servicos.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ComandaDigital.Repositorio.Impl
{
    public class UsuarioRepository : CrudRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ComandaDigitalContext dbContext) : base(dbContext)
        {

        }
        public Usuario GetUsuarioByUsernameAndSenha(string nome, string senha)
        {
            return dbContext.Set<Usuario>()
                .AsTracking()
                .FirstOrDefault(u => u.Nome.Equals(nome) && u.Senha.Equals(senha));
        }
    }
}

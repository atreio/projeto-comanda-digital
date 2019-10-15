using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigital.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ICadastroUsuarioServico cadastroUsuarioServico;
        public UsuariosController(ICadastroUsuarioServico cadastroUsuario)
        {
            this.cadastroUsuarioServico = cadastroUsuario;
        }
        public IActionResult Index()
        {
            return View(cadastroUsuarioServico.ListarTodosUsuarios());
        }
    }
}
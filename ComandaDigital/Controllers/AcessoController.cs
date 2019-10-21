using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigital.Controllers
{
    public class AcessoController : Controller
    {
        private readonly ICadastroUsuarioServico cadastroUsuarioServico;

        public AcessoController(ICadastroUsuarioServico cadastroUsuarioServico)
        {
            this.cadastroUsuarioServico = cadastroUsuarioServico;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Autenticar(string email, string senha)
        {
            try
            {
                var usuario = cadastroUsuarioServico.BuscaUsuarioPorEmailSenha(email, senha);
                if (usuario == null)
                {
                    TempData["falhaAutenticacao"] = string.Format("Usuário ou senha incorreto!");
                    return View("Index");
                }

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim("IdUsuario", usuario.Id.ToString()),
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
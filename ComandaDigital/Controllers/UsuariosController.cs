using ComandaDigital.Dtos;
using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ComandaDigital.Controllers
{
    [Route("Usuarios/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly ICadastroUsuarioServico cadastroUsuarioServico;
        public UsuariosController(ICadastroUsuarioServico cadastroUsuario)
        {
            this.cadastroUsuarioServico = cadastroUsuario;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View(cadastroUsuarioServico.ListarTodosUsuarios());
        }

        [Route("[action]")]
        public IActionResult Editar(int id)
        {
            try
            {
                var usuarioDto = new UsuarioDto();
                if (id > 0)
                    usuarioDto = cadastroUsuarioServico.BuscaUsuarioPorId(id);
                return View(usuarioDto);
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult Excluir(UsuarioDto dto)
        {
            try
            {
                cadastroUsuarioServico.ExcluirUsuario(dto);
                TempData["ocorreuGravacao"] = string.Format("Usuário {0} excluido com sucesso.", dto.Nome);

                return RedirectToAction("Index", "Usuarios", new { Area = "", id = dto.Id });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult Salva(UsuarioDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                {
                    cadastroUsuarioServico.NovoUsuario(dto);
                    TempData["ocorreuGravacao"] = string.Format("Usuário {0} cadastrado com sucesso.", dto.Nome);
                }
                else
                {
                    cadastroUsuarioServico.EditarUsuario(dto);
                    TempData["ocorreuGravacao"] = string.Format("Usuário {0} editado com sucesso.", dto.Nome);
                }

                return RedirectToAction("Index", "Usuarios", new { Area = "", id = dto.Id });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }
    }
}
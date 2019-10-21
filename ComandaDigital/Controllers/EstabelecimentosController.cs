using ComandaDigital.Dtos;
using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ComandaDigital.Controllers
{
    [Route("Estabelecimentos/[controller]")]
    public class EstabelecimentosController : Controller
    {
        private readonly IEstabelecimentoServico estabelecimentoServico;

        public EstabelecimentosController(IEstabelecimentoServico estabelecimentoServico)
        {
            this.estabelecimentoServico = estabelecimentoServico;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View(estabelecimentoServico.ListarEstabelecimentos());
        }

        [Route("[action]")]
        public IActionResult Editar(int id)
        {
            try
            {
                var estabelecimento = new EstabelecimentoDto();
                if (id > 0)
                    estabelecimento = estabelecimentoServico.BuscaUsuarioPorId(id);
                return View(estabelecimento);
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult Salva(EstabelecimentoDto dto)
        {
            try
            {
                estabelecimentoServico.EditarEstabelecimento(dto);
                TempData["ocorreuGravacao"] = string.Format("Usuário {0} editado com sucesso.", dto.Nome);

                return RedirectToAction("Index", "Estabelecimentos", new { Area = "", id = dto.Id });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }
    }
}
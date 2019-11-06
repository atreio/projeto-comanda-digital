using System;
using ComandaDigital.Dtos;
using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigital.Controllers
{
    [Route("Mesas/[controller]")]
    public class MesasController : Controller
    {
        private readonly ICadastroMesaServico cadastroMesaServico;

        public MesasController(ICadastroMesaServico MesaServico)
        {
            this.cadastroMesaServico = MesaServico;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View(cadastroMesaServico.ListarTodasMesas());
        }

        [Route("[action]")]
        public IActionResult Editar(int id)
        {
            try
            {
                var mesaDto = new MesaDto();
                if (id > 0)
                    mesaDto = cadastroMesaServico.BuscaMesaPorId(id);
                return View(mesaDto);
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult Excluir(MesaDto dto)
        {
            try
            {
                cadastroMesaServico.ExcluirMesa(dto);
                TempData["ocorreuGravacao"] = string.Format("Mesa {0} excluida com sucesso.", dto.Numero);

                return RedirectToAction("Index", "Mesas", new { Area = "", id = dto.Id });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult Salva(MesaDto dto)
        {
            try
            {
                if (dto.Id <= 0)
                {
                    cadastroMesaServico.NovaMesa(dto);
                    TempData["ocorreuGravacao"] = string.Format("Mesa {0} cadastrada com sucesso.", dto.Numero);
                }
                else
                {
                    cadastroMesaServico.EditarMesa(dto);
                    TempData["ocorreuGravacao"] = string.Format("Mesa {0} editada com sucesso.", dto.Numero);
                }

                return RedirectToAction("Index", "Mesas", new { Area = "", id = dto.Id });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }
    }
}
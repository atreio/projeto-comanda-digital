using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComandaDigital.Dtos;
using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigital.Controllers
{
    [Route("Cozinha/[controller]")]
    public class CozinhaController : Controller
    {
        private readonly IPedidoServico pedidoServico;
        private readonly ICadastroItemPedidoServico itemPedidoServico;

        public CozinhaController(IPedidoServico pedidoServico, ICadastroItemPedidoServico itemPedidoServico)
        {
            this.pedidoServico = pedidoServico;
            this.itemPedidoServico = itemPedidoServico;
        }

        [Route("[action]")]
        public IActionResult PedidoAberto()
        {
            var itens = pedidoServico.ListaTodosItemPedido();
            return View(itens);
        }

        [Route("[action]")]
        public IActionResult PedidoAndamento()
        {
            var itens = pedidoServico.ListaTodosItemPedido();
            return View(itens);
        }

        [Route("[action]")]
        public IActionResult PedidoConcluido()
        {
            var itens = pedidoServico.ListaTodosItemPedido();
            return View(itens);
        }

        [Route("[action]")]
        public IActionResult SalvaAndamento(int id)
        {
            try
            {
                itemPedidoServico.EditarAndamento(id);
                TempData["ocorreuGravacao"] = string.Format("Status do pedido alterado para: Em andamento.");

                return RedirectToAction("PedidoAndamento", "Cozinha", new { Area = "", Id = id });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult SalvaConcluido(int id)
        {
            try
            {
                itemPedidoServico.EditarAndamento(id);
                TempData["ocorreuGravacao"] = string.Format("Status do pedido alterado para: Finalizado.");

                return RedirectToAction("PedidoConcluido", "Cozinha", new { Area = "", Id = id });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }
    }
}
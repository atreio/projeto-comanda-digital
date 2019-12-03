using System;
using ComandaDigital.Dtos;
using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigital.Controllers
{
    [Route("Salao/[controller]")]
    public class SalaoController : Controller
    {
        private readonly ICadastroMesaServico cadastroMesaServico;
        private readonly IPedidoServico pedidoServico;
        private readonly ISalaoService salaoService;

        public SalaoController(ICadastroMesaServico cadastroMesaServico, ISalaoService salaoService, IPedidoServico pedidoServico)
        {
            this.cadastroMesaServico = cadastroMesaServico;
            this.salaoService = salaoService;
            this.pedidoServico = pedidoServico;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            var mesas = cadastroMesaServico.ListarTodasMesas();

            return View(mesas);
        }

        [Route("[action]")]
        public IActionResult IndexItem(int pedidoId)
        {
            try
            {
                var itens = pedidoServico.BuscarItemPorId(pedidoId).ItensPediddos;
                return View(new ItemPedidoListDto { ItensPedidos = itens, PedidoId = pedidoId });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult Alocar(int mesaId)
        {
            var mesa = cadastroMesaServico.BuscaMesaPorId(mesaId);

            return View(mesa);
        }

        [Route("[action]")]
        public IActionResult SalvaAlocacao(int mesaId, int garcomId, string clienteNome, string clienteDocumento)
        {
            salaoService.AlocarCliente(mesaId, garcomId, clienteNome, clienteDocumento);

            return RedirectToAction("Index");
        }    
    }
}
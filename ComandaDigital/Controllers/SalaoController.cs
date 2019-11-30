using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigital.Controllers
{
    [Route("Salao/[controller]")]
    public class SalaoController : Controller
    {
        private readonly ICadastroMesaServico cadastroMesaServico;
        private readonly ISalaoService salaoService;

        public SalaoController(ICadastroMesaServico cadastroMesaServico, ISalaoService salaoService)
        {
            this.cadastroMesaServico = cadastroMesaServico;
            this.salaoService = salaoService;
        }


        [Route("[action]")]
        public IActionResult Index()
        {
            var mesas = cadastroMesaServico.ListarTodasMesas();

            return View(mesas);
        }


        [Route("[action]")]
        public IActionResult Alocar(int mesaId)
        {
            var mesa = cadastroMesaServico.BuscaMesaPorId(mesaId);

            return View(mesa);
        }

        [Route("[action]")]
        public IActionResult SalvaAlocacao(int mesaId, int garconId, string clienteNome, string clienteDocumento)
        {
            salaoService.AlocarCliente(mesaId, garconId, clienteNome, clienteDocumento);

            return RedirectToAction("Index");
        }
        
    }
}
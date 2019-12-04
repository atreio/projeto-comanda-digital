using System;
using System.Linq;
using ComandaDigital.Dtos;
using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigital.Controllers
{
    [Route("Pedidos/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IPedidoServico pedidoServico;
        private readonly ICadastroUsuarioServico usuarioServico;
        private readonly ICadastroMesaServico mesaServico;
        private readonly ICadastroItemPedidoServico cadastroItemPedido;
        private readonly ICadastroProdutoServico produtoServico;

        public PedidosController(IPedidoServico pedidoServico, ICadastroUsuarioServico usuarioServico, ICadastroMesaServico mesaServico, 
            ICadastroItemPedidoServico cadastroItemPedido, ICadastroProdutoServico produtoServico)
        {
            this.pedidoServico = pedidoServico;
            this.usuarioServico = usuarioServico;
            this.mesaServico = mesaServico;
            this.cadastroItemPedido = cadastroItemPedido;
            this.produtoServico = produtoServico;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View(pedidoServico.ListarTodosPedidos());
        }

        [Route("[action]")]
        public IActionResult Editar(int id)
        {
            try
            {
                var pedido = new PedidoDto();
                var itemPedido = new ItemPedidoDto();

                if (id > 0)
                    pedido = pedidoServico.BuscaPedidoPorId(id);

                return View(pedido);
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult IndexItem(int produtoId)
        {
            try
            {
                var itens = pedidoServico.BuscaPedidoPorId(produtoId).ItensPediddos;
                return View(new ItemPedidoListDto { ItensPedidos = itens, PedidoId = produtoId });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult EditaItem(int pedidoId)
        {
            try
            {
                var item = cadastroItemPedido.BuscaItemPedidoPorId(pedidoId);
                var itemPedido = new ItemPedidoDto { PedidoId = pedidoId };
                itemPedido.Produtos = produtoServico.ListarTodosProdutos().Produtos.OrderBy(u => u.Nome).ToList();
                return View(itemPedido);
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public ActionResult SalvaItem(ItemPedidoDto dto)
        {
            try
            {
                pedidoServico.SalvarItem(dto);
                TempData["ocorreuGravacao"] = string.Format("Item {0} cadastrado com sucesso.", dto.Id);

                return RedirectToAction("Index", "Pedidos");
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }


        [Route("[action]")]
        public IActionResult Salva(PedidoDto dto)
        {
            try
            {          
                return RedirectToAction("Index", "Pedidos", new { Area = "", id = dto.Id });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }
    }
}
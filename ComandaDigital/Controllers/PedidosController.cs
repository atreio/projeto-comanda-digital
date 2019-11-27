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

        public PedidosController(IPedidoServico pedidoServico, ICadastroUsuarioServico usuarioServico, ICadastroMesaServico mesaServico)
        {
            this.pedidoServico = pedidoServico;
            this.usuarioServico = usuarioServico;
            this.mesaServico = mesaServico;
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
        public ActionResult NovoItem(int id)
        {
            try
            {
                return View("EditarItem", new ItemPedidoDto { PedidoId = id });
            }

            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult EditarItem(int id)
        {
            try
            {
                var pedido = pedidoServico.BuscarItemPorId(id);
                var item = pedido.ItensPediddos.First(f => f.Id == id);
                item.PedidoId = pedido.Id;
                return View(item);
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
                if (dto.Id <= 0)
                {
                    pedidoServico.NovoPedido(dto);
                    TempData["ocorreuGravacao"] = string.Format("Pedido da {0} Salvo com sucesso.", dto.Mesa.Numero);
                }
                else
                {
                    pedidoServico.EditarPedido(dto);
                    TempData["ocorreuGravacao"] = string.Format("Pedido da {0} editado com sucesso.", dto.Mesa.Numero);
                }

                return RedirectToAction("Index", "Pedidos", new { Area = "", id = dto.Id });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult SalvaItem(ItemPedidoDto dto)
        {
            try
            {
                pedidoServico.SalvarItem(dto);
                TempData["ocorreuGravacao"] = string.Format("Item de pedido mesa {0} cadastrado com sucesso.", dto.Pedido.Mesa.Numero);

                return RedirectToAction("IndexItemPedido", "Hospede", new { Area = "", Id = dto.PedidoId });
            }            
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }
    }
}
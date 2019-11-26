using System;
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
                var itemPedido = new ItemPedidoDto();
                pedido.ItemPedido = itemPedido;

                if (id > 0)
                    pedido = pedidoServico.BuscaPedidoPorId(id);

                pedido.ListaUsuarios = usuarioServico.ListarTodosUsuarios().Usuarios;
                pedido.ListaMesas = mesaServico.ListarTodasMesas().Mesas;

                return View(pedido);
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
                var pedido = new PedidoDto();
                var itemPedido = new ItemPedidoDto();
                pedido.ItemPedido = itemPedido;

                if (id > 0)
                    pedido = pedidoServico.BuscaPedidoPorId(id);

                pedido.ListaUsuarios = usuarioServico.ListarTodosUsuarios().Usuarios;
                pedido.ListaMesas = mesaServico.ListarTodasMesas().Mesas;

                return View(pedido);
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
    }
}
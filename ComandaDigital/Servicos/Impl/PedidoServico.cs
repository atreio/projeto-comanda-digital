using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ComandaDigital.Dtos;
using ComandaDigital.Models;
using ComandaDigital.Repositorio;

namespace ComandaDigital.Servicos.Impl
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoServico(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public PedidoDto BuscaPedidoPorId(int id)
        {
            try
            {
                var pedido = pedidoRepository.GetById(id);
                return pedido == null ? null : Mapper.Map<PedidoDto>(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarPedido(PedidoDto dto)
        {
            var pedido = pedidoRepository.GetById(dto.Id);
            if (pedido == null)
                return;

            pedido.Editar(dto.MesaId, dto.UsuarioId);
            pedidoRepository.Update(pedido);
        }

        public void ExcluirPedido(PedidoDto dto)
        {
            var pedido = pedidoRepository.GetById(dto.Id);
            if (pedido == null)
                return;

            pedidoRepository.Delete(pedido.Id);
        }

        public PedidoListDto ListarTodosPedidos()
        {
            var pedido = pedidoRepository.GetAll();
            var listPedidoDto = new PedidoListDto();

            listPedidoDto.Pedidos = Mapper.Map<List<PedidoDto>>(pedido.OrderBy(d => d.MesaId));
            return listPedidoDto;
        }

        public void NovoPedido(PedidoDto dto)
        {
            var itemPedido = new ItemPedido(dto.ItemPedido.Quantidade, dto.ItemPedido.GarcomId, dto.ItemPedido.ProdutoId, dto.ItemPedido.PedidoId, dto.ItemPedido.Descricao);
            var pedido = new Pedido(dto.MesaId, dto.UsuarioId);
            pedido.ItensPedidos.Add(itemPedido);
            pedidoRepository.Create(pedido);
        }

        public ItemPedido CriarItemPedido(ItemPedidoDto dto)
        {
            return new ItemPedido(dto.Quantidade, dto.GarcomId, dto.ProdutoId, dto.PedidoId, dto.Descricao);
        }
    }
}

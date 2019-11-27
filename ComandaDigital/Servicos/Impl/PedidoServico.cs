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
            var pedido = new Pedido(dto.MesaId, dto.UsuarioId);
            pedidoRepository.Create(pedido);
        }

        public ItemPedido CriarItemPedido(ItemPedidoDto dto, Pedido pedido)
        {
            return new ItemPedido(dto.Quantidade, dto.GarcomId, dto.ProdutoId, pedido.Id, dto.Descricao, pedido);
        }

        public PedidoDto BuscarItemPorId(int id)
        {
            var pedido = pedidoRepository.GetPedidoByItemId(id);
            if (pedido == null)
                return null;
            var dto = Mapper.Map<PedidoDto>(pedido);
            dto.ItensVinculados = pedido.ItensPedidos.Select(p => p.PedidoId).ToList();
            return dto;
        }

        public void SalvarItem(ItemPedidoDto dto)
        {
            var pedido = pedidoRepository.GetById(dto.PedidoId);

            if (dto.Id > 0)
            {
                var item = CriarItemPedido(dto, pedido);
                pedido.ItensPedidos.Add(item);
            }
            else
            {
                var item = pedido.ItensPedidos.First(i => i.Id.Equals(dto.Id));
                item.Editar(dto.Quantidade, dto.GarcomId, dto.ProdutoId, dto.ProdutoId, dto.Descricao);
            }
        }
    }
}

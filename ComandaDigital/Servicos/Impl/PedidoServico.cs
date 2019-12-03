﻿using System;
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

            listPedidoDto.Pedidos = Mapper.Map<List<PedidoDto>>(pedido);
            return listPedidoDto;
        }

        public PedidoDto NovoPedido(PedidoDto dto)
        {
            var pedido = new Pedido(dto.GarcomId, dto.ClienteDocumento, dto.ClienteNome);
            pedidoRepository.Create(pedido);

            return Mapper.Map<PedidoDto>(pedido);
        }

        public ItemPedido CriarItemPedido(ItemPedidoDto dto, Pedido pedido)
        {
            return new ItemPedido(dto.Quantidade, dto.GarcomId, dto.ProdutoId, dto.PedidoId, dto.Descricao, pedido);
        }

        public PedidoDto BuscarItemPorId(int id)
        {
            try
            {
                var pedido = pedidoRepository.GetPedidoByItemId(id);
                if (pedido == null)
                    return null;
                var dto = Mapper.Map<PedidoDto>(pedido);
                dto.ItensVinculados = pedido.ItensPedidos.Select(p => p.PedidoId).ToList();

                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SalvarItem(ItemPedidoDto dto)
        {
            var pedido = pedidoRepository.GetById(dto.PedidoId);

            if (dto.Id <= 0)
            {
                var Item = CriarItemPedido(dto, pedido);
                pedido.ItensPedidos.Add(Item);
            }
            else
            {
                var Item = pedido.ItensPedidos.First(i => i.Id.Equals(dto.Id));
                Item.Editar(dto.Quantidade, dto.GarcomId, dto.ProdutoId, dto.PedidoId, dto.Descricao);
            }
            pedidoRepository.Update(pedido);
        }
    }
}

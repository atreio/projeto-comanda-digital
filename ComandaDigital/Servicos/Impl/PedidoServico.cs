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
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoServico(IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
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

        public ItemPedidoListDto ListaTodosItemPedido()
        {
            var item = itemPedidoRepository.GetAll();
            var listItem = new ItemPedidoListDto();

            listItem.ItensPedidos = Mapper.Map<List<ItemPedidoDto>>(item);
            return listItem;
            //var pedido = itemPedidoRepository.GetById(id);
            //if (pedido == null)
            //    return null;
            //var listItens = new ItemPedidoListDto();
            //listItens.ItensPedidos = Mapper.Map<List<ItemPedidoDto>>(pedido);

            //listItens.ItensPedidos.Where(i => i.PedidoId.Equals(id)).ToList();
            ////dto.ItensVinculados = pedido.ItensPedidos.Select(p => p.PedidoId).ToList();
            //return listItens;
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
                var pedido = pedidoRepository.GetById(id);
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

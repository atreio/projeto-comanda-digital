using System;
using AutoMapper;
using ComandaDigital.Dtos;
using ComandaDigital.Models;
using ComandaDigital.Repositorio;

namespace ComandaDigital.Servicos.Impl
{
    public class CadastroItemPedidoServico : ICadastroItemPedidoServico
    {
        private readonly IItemPedidoRepository itemPedidoRepository;

        public CadastroItemPedidoServico(IItemPedidoRepository itemPedidoRepository)
        {
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public ItemPedidoDto BuscaItemPedidoPorId(int id)
        {
            try
            {
                var ItemPedido = itemPedidoRepository.GetById(id);
                return ItemPedido == null ? null : Mapper.Map<ItemPedidoDto>(ItemPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarAndamento(int id)
        {
            var ItemPedido = itemPedidoRepository.GetById(id);

            ItemPedido.AlterarEmAndamento();
            itemPedidoRepository.Update(ItemPedido);
        }

        public void EditarFinalizado(int id)
        {
            var ItemPedido = itemPedidoRepository.GetById(id);

            ItemPedido.AlterarConcluido();
            itemPedidoRepository.Update(ItemPedido);
        }

        public void EditarItemPedido(ItemPedidoDto dto)
        {
            var ItemPedido = itemPedidoRepository.GetById(dto.Id);
            if (ItemPedido == null)
                return;

            ItemPedido.Editar(dto.Quantidade, dto.GarcomId, dto.ProdutoId, dto.PedidoId, dto.Descricao);
            itemPedidoRepository.Update(ItemPedido);
        }

        public void ExcluirItemPedido(ItemPedidoDto dto)
        {
            var ItemPedido = itemPedidoRepository.GetById(dto.Id);
            if (ItemPedido == null)
                return;

            itemPedidoRepository.Delete(ItemPedido.Id);
        }

        public ItemPedidoListDto ListarTodosItemPedidos()
        {
            throw new NotImplementedException();
        }

        public void NovoItemPedido(ItemPedidoDto dto)
        {
            //var ItemPedido = new ItemPedido(dto.Quantidade, dto.GarcomId, dto.ProdutoId, dto.PedidoId, dto.Descricao, );
            //itemPedidoRepository.Create(ItemPedido);
        }
    }
}

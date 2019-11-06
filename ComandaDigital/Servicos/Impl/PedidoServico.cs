using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ComandaDigital.Dtos;
using ComandaDigital.Repositorio;

namespace ComandaDigital.Servicos.Impl
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IPedidoRepository pedidoRepository;

        PedidoServico(IPedidoRepository pedidoRepository)
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
            throw new NotImplementedException();
        }

        public void ExcluirPedido(PedidoDto dto)
        {
            throw new NotImplementedException();
        }

        public PedidoListDto ListarTodosPedidos()
        {
            throw new NotImplementedException();
        }

        public void NovoPedido(PedidoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

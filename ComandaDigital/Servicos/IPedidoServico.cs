﻿using ComandaDigital.Dtos;

namespace ComandaDigital.Servicos
{
    public interface IPedidoServico
    {
        void NovoPedido(PedidoDto dto);
        void EditarPedido(PedidoDto dto);
        PedidoDto BuscaPedidoPorId(int id);
        PedidoListDto ListarTodosPedidos();
        PedidoDto BuscarItemPorId(int id);
        void SalvarItem(ItemPedidoDto dto);
        void ExcluirPedido(PedidoDto dto);
    }
}

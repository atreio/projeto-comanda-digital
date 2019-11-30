﻿using ComandaDigital.Dtos;

namespace ComandaDigital.Servicos
{
    public interface IPedidoServico
    {
        PedidoDto NovoPedido(PedidoDto dto);
        void EditarPedido(PedidoDto dto);
        PedidoDto BuscaPedidoPorId(int id);
        PedidoListDto ListarTodosPedidos();
        void ExcluirPedido(PedidoDto dto);
    }
}

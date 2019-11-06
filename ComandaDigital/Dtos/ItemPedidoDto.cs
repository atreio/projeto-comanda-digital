using ComandaDigital.Enums;
using ComandaDigital.Models;
using System;
using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class ItemPedidoDto
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public StatusPedido Status { get; set; }
        public int UsuarioId { get; set; }
        public int GarcomId { get; set; }
        public Usuario Usuario { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public string Descricao { get; set; }
    }

    public class ItemPedidoListDto
    {
        public List<ItemPedidoListDto> ItensPedidos { get; set; }
        public int PedidoId { get; set; }
    }
}

using ComandaDigital.Enums;
using ComandaDigital.Models;
using System;
using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class ItemPedidoDto
    {
        public ItemPedidoDto()
        {
            Produto = new ProdutoDto();
            Usuario = new UsuarioDto();
            Pedido = new PedidoDto();
        }

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public StatusPedido Status { get; set; }
        public int UsuarioId { get; set; }
        public int GarcomId { get; set; }
        public int CozinheiroId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoDto Produto { get; set; }
        public int PedidoId { get; set; }
        public PedidoDto Pedido { get; set; }
        public string Descricao { get; set; }
        public List<ProdutoDto> Produtos { get; set; }
        public List<UsuarioDto> Usuarios { get; set; }
    }

    public class ItemPedidoListDto
    {
        public List<ItemPedidoDto> ItensPedidos { get; set; }       
        public int PedidoId { get; set; }
    }
}

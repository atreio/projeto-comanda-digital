using ComandaDigital.Enums;
using ComandaDigital.Models.Base;
using System;

namespace ComandaDigital.Models
{
    public class ItemPedido : IEntity
    {
        public ItemPedido() { }

        public ItemPedido(int quantidade, int garcomId, int produtoId, int pedidoId, string descricao)
        {
            Quantidade = quantidade;
            DataCriacao = DateTime.Now;
            Status = StatusPedido.PedidodRealizado;
            GarcomId = garcomId;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            Descricao = descricao;
        }

        public int Quantidade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public StatusPedido Status { get; set; }
        public int CozinheiroId { get; set; }
        public int GarcomId { get; set; }
        public Usuario Usuario { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public string Descricao { get; set; }

        public void Editar(int quantidade, StatusPedido status, int garcomId, int produtoId, int pedidoId, string descricao)
        {
            Quantidade = quantidade;
            DataAtualizacao = DateTime.Now;
            Status = status;
            GarcomId = garcomId;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            Descricao = descricao;
        }
    }
}

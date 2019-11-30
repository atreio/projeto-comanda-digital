using ComandaDigital.Enums;
using ComandaDigital.Models.Base;
using System;

namespace ComandaDigital.Models
{
    public class ItemPedido : IEntity
    {
        public ItemPedido() { }
        public ItemPedido(int quantidade, int garcomId, int produtoId, int pedidoId, string descricao, Pedido pedido)
        {
            Quantidade = quantidade;
            DataCriacao = DateTime.Now;
            Status = StatusPedido.PedidodRealizado;
            GarcomId = garcomId;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            Descricao = descricao;
            Pedido = pedido;
        }

        public int Quantidade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public StatusPedido Status { get; set; }
        public virtual int CozinheiroId { get; set; }
        public virtual int GarcomId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public string Descricao { get; set; }

        public void Editar(int quantidade, int garcomId, int produtoId, int pedidoId, string descricao)
        {
            Quantidade = quantidade;
            DataAtualizacao = DateTime.Now;
            GarcomId = garcomId;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            Descricao = descricao;
        }
    }
}

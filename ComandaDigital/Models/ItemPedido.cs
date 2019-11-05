using ComandaDigital.Enums;
using ComandaDigital.Models.Base;
using System;

namespace ComandaDigital.Models
{
    public class ItemPedido : IEntity
    {
        ItemPedido() { }

        public int Quantidade { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public StatusPedido Status { get; set; }
        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }
        public string Descricao { get; set; }
    }
}

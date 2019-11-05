using ComandaDigital.Models.Base;
using System.Collections.Generic;

namespace ComandaDigital.Models
{
    public class Pedido : IEntity
    {
        Pedido() { }

        public Mesa Mesa { get; set; }
        public Usuario Usuario { get; set; }
        public List<ItemPedido> ItensPedidos { get; set; }
    }
}

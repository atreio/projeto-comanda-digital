using ComandaDigital.Models.Base;
using System.Collections.Generic;

namespace ComandaDigital.Models
{
    public class Pedido : IEntity
    {
        public Pedido() { }

        public Pedido(int mesaId, int usuarioId)
        {
            MesaId = mesaId;
            UsuarioId = usuarioId;
            ItensPedidos = new List<ItemPedido>();
        }

        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<ItemPedido> ItensPedidos { get; set; }
    }
}

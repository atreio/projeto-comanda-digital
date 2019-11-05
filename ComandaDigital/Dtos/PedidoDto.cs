using ComandaDigital.Models;
using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public Mesa Mesa { get; set; }
        public Usuario Usuario { get; set; }
        public List<ItemPedido> ItensPediddos { get; set; }
    }

    public class PedidoListDto
    {
        public List<PedidoDto> Pedidos { get; set; }
    }
}

using ComandaDigital.Models;
using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class PedidoDto
    {
        public PedidoDto()
        {
            ItensPediddos = new List<ItemPedidoDto>();
        }

        public int Id { get; set; }
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<ItemPedidoDto> ItensPediddos { get; set; }
    }

    public class PedidoListDto
    {
        public List<PedidoDto> Pedidos { get; set; }
    }
}

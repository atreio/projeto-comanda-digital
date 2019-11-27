using ComandaDigital.Models;
using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class PedidoDto
    {
        public PedidoDto()
        {
            ItensPediddos = new List<ItemPedidoDto>();
            ItensVinculados = new List<int>();
        }

        public int Id { get; set; }
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ItemPedidoDto ItemPedido { get; set; }
        public List<ItemPedidoDto> ItensPediddos { get; set; }
        public List<UsuarioDto> ListaUsuarios { get; set; }
        public List<MesaDto> ListaMesas { get; set; }
        public List<int> ItensVinculados { get; set; }
    }

    public class PedidoListDto
    {
        public List<PedidoDto> Pedidos { get; set; }
        public List<MesaDto> Mesas { get; set; }
        public List<UsuarioDto> Usuarios { get; set; }
    }
}

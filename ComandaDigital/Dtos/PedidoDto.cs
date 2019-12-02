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
        public int GarcomId { get; set; }
        public UsuarioDto Garcom { get; set; }
        public List<ItemPedidoDto> ItensPediddos { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteDocumento { get; set; }
        public bool EmAberto { get; set; }
    }

    public class PedidoListDto
    {
        public List<PedidoDto> Pedidos { get; set; }
    }
}

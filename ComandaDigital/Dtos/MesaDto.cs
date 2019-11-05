using ComandaDigital.Models;
using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class MesaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }

    public class MesaListDto
    {
        public List<MesaDto> Mesas { get; set; }
    }
}

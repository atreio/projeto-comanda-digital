using ComandaDigital.Models;
using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class MesaDto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int EstabelecimentoId { get; set; }
        public EstabelecimentoDto Estabelecimento { get; set; }
        public bool Ocupada { get; set; }
        public PedidoDto Pedido { get; set; }
        public int PedidoId { get; set; }
    }

    public class MesaListDto
    {
        public List<MesaDto> Mesas { get; set; }
    }
}

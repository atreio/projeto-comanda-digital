using ComandaDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComandaDigital.Dtos
{
    public class MesaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        public class MesaDtoList
        {
            public List<MesaDto> Mesas { get; set; }
        }
    }
}

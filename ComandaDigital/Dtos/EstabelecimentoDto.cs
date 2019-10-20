using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class EstabelecimentoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
    public class EstabelecimentoListDto
    {
        public List<EstabelecimentoDto> Estabelecimentos { get; set; }
    }
}

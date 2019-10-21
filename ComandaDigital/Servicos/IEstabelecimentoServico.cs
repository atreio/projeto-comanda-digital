using ComandaDigital.Dtos;

namespace ComandaDigital.Servicos
{
    public interface IEstabelecimentoServico
    {
        void EditarEstabelecimento(EstabelecimentoDto dto);
        EstabelecimentoDto BuscaUsuarioPorId(int id);
        EstabelecimentoListDto ListarEstabelecimentos();
    }
}

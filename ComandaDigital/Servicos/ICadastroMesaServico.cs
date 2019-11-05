using ComandaDigital.Dtos;

namespace ComandaDigital.Servicos
{
    public interface ICadastroMesaServico
    {
        void NovaMesa(MesaDto dto);
        void EditarMesa(MesaDto dto);
        MesaDto BuscaMesaPorId(int id);
        MesaListDto ListarTodasMesas();
        void ExcluirMesa(MesaDto dto);
    }
}

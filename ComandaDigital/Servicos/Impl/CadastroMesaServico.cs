using System;
using ComandaDigital.Dtos;
using ComandaDigital.Repositorio;

namespace ComandaDigital.Servicos.Impl
{
    public class CadastroMesaServico : ICadastroMesaServico
    {
        private readonly IMesaRepository mesaRepository;

        public CadastroMesaServico(IMesaRepository mesaRepository)
        {
            this.mesaRepository = mesaRepository;
        }

        public MesaDto BuscaMesaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void EditarMesa(MesaDto dto)
        {
            throw new NotImplementedException();
        }

        public void ExcluirMesa(MesaDto dto)
        {
            throw new NotImplementedException();
        }

        public MesaListDto ListarTodasMesas()
        {
            throw new NotImplementedException();
        }

        public void NovaMesa(MesaDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ComandaDigital.Dtos;
using ComandaDigital.Models;
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
            try
            {
                var mesa = mesaRepository.GetById(id);
                return mesa == null ? null : Mapper.Map<MesaDto>(mesa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarMesa(MesaDto dto)
        {
            var mesa = mesaRepository.GetById(dto.Id);
            if (mesa == null)
                return;

            mesa.Editar(dto.Numero, dto.Descricao, dto.Quantidade);
            mesaRepository.Update(mesa);
        }

        public void ExcluirMesa(MesaDto dto)
        {
            var mesa = mesaRepository.GetById(dto.Id);
            if (mesa == null)
                return;

            mesaRepository.Delete(mesa.Id);
        }

        public MesaListDto ListarTodasMesas()
        {
            var mesa = mesaRepository.GetAll();
            var listMesaDto = new MesaListDto();

            listMesaDto.Mesas = Mapper.Map<List<MesaDto>>(mesa.OrderBy(d => d.Numero));
            return listMesaDto;
        }

        public void NovaMesa(MesaDto dto)
        {
            var mesa = new Mesa(dto.Numero, dto.Descricao, dto.Quantidade);
            mesaRepository.Create(mesa);
        }
    }
}

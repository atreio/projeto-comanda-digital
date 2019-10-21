using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ComandaDigital.Dtos;
using ComandaDigital.Repositorio;

namespace ComandaDigital.Servicos.Impl
{
    public class EstabelecimentoServico : IEstabelecimentoServico
    {
        private readonly IEstabelecimentoRepository estabelecimentoRepository;

        public EstabelecimentoServico(IEstabelecimentoRepository estabelecimentoRepository)
        {
            this.estabelecimentoRepository = estabelecimentoRepository;
        }

        public EstabelecimentoDto BuscaUsuarioPorId(int id)
        {
            try
            {
                var estabelecimento = estabelecimentoRepository.GetById(id);
                return estabelecimento == null ? null : Mapper.Map<EstabelecimentoDto>(estabelecimento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarEstabelecimento(EstabelecimentoDto dto)
        {
            var estabelecimento = estabelecimentoRepository.GetById(dto.Id);
            if (estabelecimento == null)
                return;

            estabelecimento.EditarEstabelecimento(dto.Nome);
            estabelecimentoRepository.Update(estabelecimento);
        }

        public EstabelecimentoListDto ListarEstabelecimentos()
        {
            var estabelecimento = estabelecimentoRepository.GetAll();
            var listEstabelecimentoDto = new EstabelecimentoListDto();

            listEstabelecimentoDto.Estabelecimentos = Mapper.Map<List<EstabelecimentoDto>>(estabelecimento.OrderBy(d => d.Nome));
            return listEstabelecimentoDto;
        }
    }
}

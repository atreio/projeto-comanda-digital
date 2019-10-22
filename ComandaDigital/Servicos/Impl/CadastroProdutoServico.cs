using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ComandaDigital.Dtos;
using ComandaDigital.Models;
using ComandaDigital.Repositorio;

namespace ComandaDigital.Servicos.Impl
{
    public class CadastroProdutoServico : ICadastroProdutoServico
    {
        private readonly IProdutoRepository produtoRepository;

        public CadastroProdutoServico(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public ProdutoDto BuscaProdutoPorId(int id)
        {
            try
            {
                var produto = produtoRepository.GetById(id);
                return produto == null ? null : Mapper.Map<ProdutoDto>(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarProduto(ProdutoDto dto)
        {
            var produto = produtoRepository.GetById(dto.ID);
            if (produto == null)
                return;

            produto.Editar(dto.Nome, dto.ValorCusto, dto.ValorVenda);
            produtoRepository.Update(produto);
        }

        public void ExcluirProduto(ProdutoDto dto)
        {
            var produto = produtoRepository.GetById(dto.ID);
            if (produto == null)
                return;

            produtoRepository.Delete(produto.Id);
        }

        public ProdutoListDto ListarTodosProdutos()
        {
            var produto = produtoRepository.GetAll();
            var listProdutoDto = new ProdutoListDto();

            listProdutoDto.Produtos = Mapper.Map<List<ProdutoDto>>(produto.OrderBy(d => d.Nome));
            return listProdutoDto;
        }

        public void NovoProduto(ProdutoDto dto)
        {
            var Produto = new Produto(dto.Nome, dto.ValorCusto, dto.ValorVenda);
            produtoRepository.Create(Produto);
        }
    }
}

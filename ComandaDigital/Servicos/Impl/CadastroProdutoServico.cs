using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComandaDigital.Dtos;

namespace ComandaDigital.Servicos.Impl
{
    public class CadastroProdutoServico : ICadastroProdutoServico
    {
        private readonly ICadastroProdutoServico cadastroProdutoServico;

        public CadastroProdutoServico(ICadastroProdutoServico cadastroProdutoServico)
        {
            this.cadastroProdutoServico = cadastroProdutoServico;
        }

        public ProdutoDto BuscaProdutoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void EditarProduto(ProdutoDto dto)
        {
            throw new NotImplementedException();
        }

        public ProdutoListDto ListarTodosProdutos()
        {
            throw new NotImplementedException();
        }

        public void NovoProduto(ProdutoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

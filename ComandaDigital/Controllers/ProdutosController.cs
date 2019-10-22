using System;
using ComandaDigital.Dtos;
using ComandaDigital.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigital.Controllers
{
    [Route("Produtod/[controller]")]
    public class ProdutosController : Controller
    {
        private readonly ICadastroProdutoServico cadastroProdutoServico;

        public ProdutosController(ICadastroProdutoServico cadastroProdutoServico)
        {
            this.cadastroProdutoServico = cadastroProdutoServico;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View(cadastroProdutoServico.ListarTodosProdutos());
        }

        [Route("[action]")]
        public IActionResult Editar(int id)
        {
            try
            {
                var produtoDto = new ProdutoDto();
                if (id > 0)
                    produtoDto = cadastroProdutoServico.BuscaProdutoPorId(id);
                return View(produtoDto);
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult Excluir(ProdutoDto dto)
        {
            try
            {
                cadastroProdutoServico.ExcluirProduto(dto);
                TempData["ocorreuGravacao"] = string.Format("Produto {0} excluido com sucesso.", dto.Nome);

                return RedirectToAction("Index", "Produtos", new { Area = "", id = dto.ID });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        [Route("[action]")]
        public IActionResult Salva(ProdutoDto dto)
        {
            try
            {
                if (dto.ID <= 0)
                {
                    cadastroProdutoServico.NovoProduto(dto);
                    TempData["ocorreuGravacao"] = string.Format("Produto {0} cadastrado com sucesso.", dto.Nome);
                }
                else
                {
                    cadastroProdutoServico.EditarProduto(dto);
                    TempData["ocorreuGravacao"] = string.Format("Produto {0} editado com sucesso.", dto.Nome);
                }

                return RedirectToAction("Index", "Produtos", new { Area = "", id = dto.ID });
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }
    }
}
using Business.Excecoes;
using Microsoft.AspNetCore.Mvc;
using Repository.Entidades;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace webapi.Controllers
{
    [ApiController]
    [Route("/api/produtos/")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> Get()
        {
            var produtos = await _produtoRepositorio.Get();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                var produto = await _produtoRepositorio.GetById(id);
                if (produto != null)
                {
                    return Ok(produto);
                }else
                {
                    return BadRequest("Categoria não encontrada");
                }
            }
            else
            {
                throw new BusinessException("Oops! Ocorreu um erro.");
            }
        }

        [HttpGet("search")]
        public ActionResult<List<ProdutoModel>> Get([FromQuery] string descricao)
        {
            List<ProdutoModel> produto = _produtoRepositorio.GetByDescription(descricao);
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoInputModel produtoInputModel)
        {
            if (ModelState.IsValid)
            {
                var produto = new ProdutoModel(produtoInputModel.Codigo, produtoInputModel.Descricao, produtoInputModel.Preco, produtoInputModel.UnidadeMedida, produtoInputModel.Categoria.Id);
                _produtoRepositorio.Post(produto);
                return Ok(produto);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ProdutoInputModel produtoInputModel, Guid id)
        {
            if (produtoInputModel == null)
            {
                return BadRequest("Campos vazios");
            }

            await _produtoRepositorio.Put(id, produtoInputModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _produtoRepositorio.Remove(id);
            return Ok();
        }
    }
}

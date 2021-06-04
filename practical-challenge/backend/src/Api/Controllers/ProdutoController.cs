using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;

using Business.Entidades;
using Repository.Interfaces;

namespace webapi.Controllers
{
    [ApiController]
    [Route("/api/produtos/")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IValidator<ProdutoInputModel> _validateProduto;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, IValidator<ProdutoInputModel> validateProduto)
        {
            _produtoRepositorio = produtoRepositorio;
            _validateProduto = validateProduto;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> Get()
        {
            var produtos = await _produtoRepositorio.GetAll();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> Get(Guid id)
        {
            var produto = await _produtoRepositorio.GetById(id);

            if (produto == null)
                return NotFound("Produto não encontrada");

            return Ok(produto);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<ProdutoModel>>> Get([FromQuery] string descricao)
        {
            if (descricao == null)
            {
                List<ProdutoModel> produtos = await _produtoRepositorio.GetAll();
                return Ok(produtos);
            }

            List<ProdutoModel> produto = await _produtoRepositorio.GetByDescription(descricao);

            if (produto == null)
                return NotFound("Produto não encontrada");

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutoInputModel inputModel)
        {
            List<string> response = new List<string>();

            var validationResult = _validateProduto.Validate(inputModel);

            if (validationResult.IsValid)
            {
                var produto = new ProdutoModel(inputModel);

                _produtoRepositorio.Post(produto);
                return Ok();

            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    response.Add(error.ErrorMessage);
                }
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] ProdutoInputModel inputModel, Guid id)
        {
            List<string> response = new List<string>();

            if (inputModel.Codigo == null || inputModel.Codigo == "")
            {
                _produtoRepositorio.Put(id, inputModel);
                return Ok();
            }
            else
            {
                var validationResult = _validateProduto.Validate(inputModel);

                if (validationResult.IsValid)
                {
                    _produtoRepositorio.Put(id, inputModel);
                    return Ok();
                }
                else
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.Add(error.ErrorMessage);
                    }
                }
            }

            return BadRequest(response);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _produtoRepositorio.Remove(id);
            return Ok();
        }
    }
}

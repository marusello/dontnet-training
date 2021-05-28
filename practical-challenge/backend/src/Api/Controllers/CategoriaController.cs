using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using Business.Entidades;
using Repository.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/categorias/")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IValidator<CategoriaInputModel> _validateCategoria;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio, IValidator<CategoriaInputModel> validateCategoria)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _validateCategoria = validateCategoria;

        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaModel>>> Get()
        {
            List<CategoriaModel> listaCategorias = await _categoriaRepositorio.GetAll();
            return Ok(listaCategorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModel>> Get(Guid id)
        {
            var categoria = await _categoriaRepositorio.GetById(id);

            if (categoria != null)
            {
                return Ok(categoria);
            }
            else
            {
                return NotFound("Categoria não encontrada");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<CategoriaModel>>> Get([FromQuery] string descricao)
        {
            if (descricao == null)
            {
                List<CategoriaModel> categorias = await _categoriaRepositorio.GetAll();
                return Ok(categorias);
            }

            List<CategoriaModel> categoria = await _categoriaRepositorio.GetByDescription(descricao);

            if (categoria != null)
            {
                return Ok(categoria);
            }
            else
            {
                return NotFound("Categoria não encontrada");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoriaInputModel inputModel)
        {
            List<string> response = new List<string>();

            var validationResult = _validateCategoria.Validate(inputModel);

            if (validationResult.IsValid)
            {
                var categoria = new CategoriaModel(inputModel.Codigo, inputModel.Descricao);

                _categoriaRepositorio.Post(categoria);
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
        public IActionResult Put([FromBody] CategoriaInputModel inputModel, Guid id)
        {
            _categoriaRepositorio.Put(id, inputModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var isValide = await _categoriaRepositorio.Remove(id);

            if (isValide != true)
            {
                return Ok();
            }

            return BadRequest("Categoria não pode ser apagada, pois está vinculada produto");
        }
    }
}

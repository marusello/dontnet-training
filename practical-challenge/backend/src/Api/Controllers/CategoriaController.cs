using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Entidades;
using Repository.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/categorias/")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;        

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;          
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaModel>>> GetCategorias()
        {
            List<CategoriaModel> listaCategorias = await _categoriaRepositorio.Get();
            return Ok(listaCategorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModel>> Get(Guid id)
        {
            var categoria = await _categoriaRepositorio.GetById(id);
            return Ok(categoria);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<CategoriaModel>>> Get([FromQuery] string descricao)
        {
            List<CategoriaModel> categoria =
                await _categoriaRepositorio.GetByDescription(descricao);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaInputModel categoriaInputModel)
        {
            if (categoriaInputModel == null)
            {
                return BadRequest("Campos vazios");
            }

            var categoria = new CategoriaModel(categoriaInputModel.Codigo, categoriaInputModel.Descricao);

            await _categoriaRepositorio.Post(categoria);
            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CategoriaInputModel categoriaInputModel, Guid id)
        {
            if (categoriaInputModel == null)
            {
                return BadRequest("Campos vazios");
            }

            await _categoriaRepositorio.Put(id, categoriaInputModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _categoriaRepositorio.Remove(id);
            return Ok();
        }
    }
}

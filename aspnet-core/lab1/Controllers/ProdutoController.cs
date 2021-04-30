using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using lab1.Models;
using lab1.Repositories;

namespace lab1.Controllers
{
    [ApiController]
    [Route("api/produtos/")]
    public class ProdutoController : ControllerBase
    {      
        private readonly IProdutoRepositorio _produto;

        public ProdutoController(IProdutoRepositorio produto) 
        {
            _produto = produto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produto.GetAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {  
            var oldProduto = _produto.Get(id);

            if (oldProduto == null) 
            {
                return NotFound();
            }
            
            return Ok(oldProduto);
        }


        [HttpPost]
        public IActionResult Post([FromBody]Produto produto)
        {    
            _produto.Add(produto);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Produto produto)
        {
            var oldProduto = _produto.Get(id);

            if (oldProduto == null) 
            {
                return NotFound();
            }

            oldProduto.Nome = produto.Nome;
            oldProduto.Valor = produto.Valor;

            _produto.Update(oldProduto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var oldProduto = _produto.Get(id);

            if (oldProduto == null) 
            {
                return NotFound();
            }

            _produto.Remove(oldProduto.Id);
            
            return Ok();
        }
    }
}

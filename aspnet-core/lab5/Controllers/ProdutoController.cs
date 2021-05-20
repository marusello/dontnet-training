
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lab5.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

[ApiController]
[Route("api")]
public class ProdutoController : ControllerBase
{ 
  private readonly ProdutoRepositorio _repositorio;

  public ProdutoController(ProdutoRepositorio repositorio)
  {
      _repositorio = repositorio;
  }

    [HttpGet]
    public async Task<ActionResult<List<Produto>>> Get()
    {   
      List<Produto> listaData = await _repositorio.Get();  

      return Ok(listaData);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> Get(Guid id)
    {   
      Produto produto = await _repositorio.GetById(id);  

      return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Produto produto)
    {
      await _repositorio.Create(produto);
      return Ok(produto);
    }
}
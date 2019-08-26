using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        LivroRepository livroRepository = new LivroRepository();

        [HttpGet]
        public IEnumerable<Livros> Listar()
        {
            return livroRepository.Listar();

        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Livros livros = livroRepository.BuscarPorId(id);
            if (livros == null)
            {
                return NotFound();
            }
            return Ok(livros);
        }

        [HttpPost]
        public IActionResult Cadastrar(Livros livro)
        {
            livroRepository.Cadastrar(livro);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Livros livro)
        {
            livroRepository.Alterar(id, livro);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            livroRepository.Deletar(id);
            return Ok();
        }

    }
}
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
    public class AutoresController : ControllerBase
    {
        AutorRepository autorRepository = new AutorRepository();

        [HttpGet]
        public IEnumerable<Autores> Listar()
        {
            return autorRepository.Listar();

        }

        [HttpGet("{id}")]
        public IEnumerable<Autores> BuscarPorId(int id)
        {
            return autorRepository.BuscarPorId(id);
        }

        [HttpPost]
        public IActionResult Cadastrar(Autores autor)
        {
            autorRepository.Cadastrar(autor);
            return Ok();
        }
    }
}
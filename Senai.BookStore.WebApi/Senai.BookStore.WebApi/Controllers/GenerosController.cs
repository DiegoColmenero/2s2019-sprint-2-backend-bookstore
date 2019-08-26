using Senai.BookStore.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;

namespace Senai.BookStore.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository generoRepository = new GeneroRepository();

        [HttpGet]
        public IEnumerable<Generos> Listar()
        {
            return generoRepository.Listar();

        }

        [HttpPost]
        public IActionResult Cadastrar(Generos genero)
        {
            generoRepository.Cadastrar(genero);

            return Ok();
        }
    }
}
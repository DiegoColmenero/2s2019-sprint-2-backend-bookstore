using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Domains
{
    public class Livros
    {
        public int IdLivro { get; set; }
        public string Livro { get; set; }
        public int GeneroId { get; set; }
        public int AutorId { get; set; }
        public Generos Genero { get; set; }
        public Autores Autor { get; set; }
    }
}

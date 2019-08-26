using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class LivroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore; User Id=sa; Pwd=132";

        public List<Livros> Listar()
        {
            List<Livros> livros = new List<Livros>();
            
            using(SqlConnection connection = new SqlConnection(StringConexao))
            {
                string Query = "select Livros.IdLivro, Livros.Livro, Generos.Genero, Autores.Nome from Livros join Generos on Livros.IdGenero = Generos.IdGenero join Autores on Livros.IdAutor = Autores.IdAutor";
                connection.Open();
                SqlDataReader rdr;

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        Livros livro = new Livros
                        {
                            IdLivro = Convert.ToInt32(rdr["IdLivro"]),
                            Livro = rdr["Livro"].ToString(),
                            Genero = new Generos()
                            {
                                Genero = rdr["Genero"].ToString()
                            },
                            Autor = new Autores()
                            {
                                Nome = rdr["Nome"].ToString()
                            }
                        };
                        livros.Add(livro);
                    }
                }

            }return livros;
        }

        public Livros BuscarPorId(int id)
        {
            List<Livros> livros = new List<Livros>();



            string Query = "select Livros.IdLivro, Livros.Livro, Generos.Genero, Autores.Nome from Livros join Generos on Livros.IdGenero = Generos.IdGenero join Autores on Livros.IdAutor = Autores.IdAutor where IdLivro = @IdLivro";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdLivro", id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Livros livro = new Livros
                            {
                                IdLivro = Convert.ToInt32(rdr["IdLivro"]),
                                Livro = rdr["Livro"].ToString(),
                                Genero = new Generos()
                                {
                                    Genero = rdr["Genero"].ToString()
                                },
                                Autor = new Autores()
                                {
                                    Nome = rdr["Nome"].ToString()
                                }
                            };
                            return livro;
                        }

                    }
                    return null;
                }
            }
        }

        public void Cadastrar(Livros livro)
        {
            string Query = "insert into Livros (Livro,IdGenero,IdAutor) values(@Livro,@IdGenero,@IdAutor)";

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Livro", livro.Livro);
                command.Parameters.AddWithValue("@IdGenero", livro.GeneroId);
                command.Parameters.AddWithValue("@IdAutor", livro.AutorId);
                connection.Open();
                command.ExecuteNonQuery();



            }
        }

        public void Alterar(int id, Livros livro)
        {
            string Query = "update Livros set Livro = @Livro where IdLivro = @IdLivro";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdLivro", id);
                cmd.Parameters.AddWithValue("@Livro", livro.Livro);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "delete from Livros where IdLivro = @IdLivro";
            using (SqlConnection conection = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(Query, conection);
                command.Parameters.AddWithValue("@IdLivro", id);
                conection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

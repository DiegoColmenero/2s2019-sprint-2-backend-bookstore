using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class AutorRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore; User Id=sa; Pwd=132";

        public List<Autores> Listar()
        {
            List<Autores> autores = new List<Autores>();

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string Query = "select * from Autores order by IdAutor asc";
                connection.Open();
                SqlDataReader rdr;


                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        Autores autor = new Autores
                        {
                            IdAutor = Convert.ToInt32(rdr["IdAutor"]),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Ativo = Convert.ToBoolean(rdr["Ativo"]),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };
                        autores.Add(autor);
                    }
                }
            }
            return autores;
        }

        public List<Autores> BuscarPorId(int id)
        {
            List<Autores> autores = new List<Autores>();



            string Query = "select Autores.*, Livros.Livro from Autores join Livros on Autores.IdAutor = Livros.IdAutor  where Livros.IdAutor = @IdAutor";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdAutor", id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Autores autor = new Autores
                            {
                                IdAutor = Convert.ToInt32(rdr["IdAutor"]),
                                Nome = rdr["Nome"].ToString(),
                                Email = rdr["Email"].ToString(),
                                Ativo = Convert.ToBoolean(rdr["Ativo"]),
                                DataNascimento = Convert.ToDateTime(rdr["DataNascimento"]),
                                Livro = new Livros()
                                {
                                    Livro = rdr["Livro"].ToString(),
                                }
                            }; autores.Add(autor);


                        }
                        }
                        return autores;
                }
            }
        }

        public void Cadastrar(Autores autor)
        {
            string Query = "insert into Autores (Nome,Email,DataNascimento) values (@Nome,@Email,@DataNascimento)";

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Nome", autor.Nome);
                command.Parameters.AddWithValue("@Email", autor.Email);
                command.Parameters.AddWithValue("@DataNascimento", autor.DataNascimento);
                connection.Open();
                command.ExecuteNonQuery();



            }
        }
    }
}

using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore; User Id=sa; Pwd=132";

        public List<Generos> Listar()
        {
            List<Generos> generos = new List<Generos>();

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                string Query = "select * from Generos order by IdGenero asc";
                connection.Open();
                SqlDataReader rdr;


                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        Generos genero = new Generos
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Genero = rdr["Genero"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }

        public void Cadastrar(Generos genero)
        {
            string Query = "insert into Generos (Genero) values(@Genero)";

            using (SqlConnection connection = new SqlConnection(StringConexao))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Genero", genero.Genero);
                connection.Open();
                command.ExecuteNonQuery();
                

                
            }
        }
    }
}

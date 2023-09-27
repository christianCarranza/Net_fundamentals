using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AdoNet
{
    public class ArtistRepository
    {
        private string _ConnectionString;

        public ArtistRepository(string connectionstring)
        {
            _ConnectionString = connectionstring;
        }

        public int Contar()
        {
            string query = "Select count(1) from Artist";
            using (SqlConnection cnx = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, cnx);
                cnx.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public Artist GetArtistPorId(int id)
        {
            string proc = "dbo.ArtistaPorid";
            using (SqlConnection cnx = new SqlConnection(_ConnectionString))
            {
                cnx.Open();
                SqlCommand command = new SqlCommand(proc, cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ArtistId", id);

                var reader = command.ExecuteReader();
                Artist artista = new Artist();
                
                while(reader.Read())
                {
                    artista.Artistid = Convert.ToInt32(reader["ArtistId"]);
                    artista.Name = reader["Name"].ToString();
                }

                return artista;
            }
        }

        public IEnumerable<Artist> GetListaArtista()
        {
            string proc = "dbo.GetListaArtista";
            List<Artist> listaartista= new List<Artist>();
            using (SqlConnection cnx = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(proc, cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cnx.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    listaartista.Add(new Artist
                    {
                        Artistid = Convert.ToInt32(reader["ArtistId"]),
                        Name = reader["Name"].ToString()
                    });

                    //Artist artista = new Artist();
                    //artista.Artistid = Convert.ToInt32(reader["ArtistId"]);
                    //artista.Name = reader["Name"].ToString();

                    //listaartista.Add(artista);
                }
            }
            return listaartista;
        }

        public int InsertArtista(string name)
        {
            string proc = "dbo.InsertArtista";
            using (SqlConnection cnx = new SqlConnection(_ConnectionString))
            {
                cnx.Open();
                SqlCommand command = new SqlCommand(proc, cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Name", name);

                return (int)command.ExecuteScalar();
            }
        }

        public int InsertArtistaTransaction(string name)
        {
            string proc = "dbo.InsertArtista";
            int resultado = 0;
            using (SqlConnection cnx = new SqlConnection(_ConnectionString))
            {
                cnx.Open();
                var SqlTransaction = cnx.BeginTransaction();
                SqlCommand command = new SqlCommand(proc, cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Transaction = SqlTransaction;
                command.Parameters.AddWithValue("@Name", name);

                try
                {
                    resultado = (int)command.ExecuteScalar();
                    SqlTransaction.Commit();
                }
                catch(Exception)
                {
                    SqlTransaction.Rollback();
                    resultado = 0;
                }

                return resultado;
            }
        }
    }
}

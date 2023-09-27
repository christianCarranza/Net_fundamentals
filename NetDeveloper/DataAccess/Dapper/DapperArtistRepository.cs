using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Dapper
{
    public class DapperArtistRepository
    {
        private string _ConnectionString;


        public DapperArtistRepository(string conectionstring)
        {
            _ConnectionString = conectionstring;
        }

        public int Contar()
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                return connection.ExecuteScalar<int>("Select count(1) from Artist");
            }
        }

        public IEnumerable<Artist> GetListaArtista()
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                return connection.Query<Artist>("dbo.GetListaArtista");
            }
        }

        public Artist GetArtistaPorId(int id)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ArtistId", id);

                return connection.QueryFirst<Artist>("dbo.ArtistaPorid", parameters,commandType:System.Data.CommandType.StoredProcedure);
            }
        }

        public int InsertArtistaTransaccion(string name)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                int artistaid = 0;
                using (var transaccion = new TransactionScope())
                {
                    artistaid = connection.Query<int>("dbo.InsertArtista",
                        new { Name = name }, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    transaccion.Complete();
                }
                return artistaid;
            }
        }
    }
}

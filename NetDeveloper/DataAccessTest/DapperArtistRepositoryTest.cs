using DataAccess.Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Linq;

namespace DataAccessTest
{
    [TestClass]
    public class DapperArtistRepositoryTest
    {
        private DapperArtistRepository _dapper;

        public DapperArtistRepositoryTest()
        {
            _dapper = new DapperArtistRepository(ConfigurationManager.ConnectionStrings["Chinookcnx"].ConnectionString);
        }

        [TestMethod]
        public void TestDapper_ListaArtista()
        {
            var listaartista = _dapper.GetListaArtista();
            Assert.AreEqual(listaartista.Count() > 0, true);
        }

        [TestMethod]
        public void TestDapper_Conexion_Artist_Cantidad()
        {
            var count = _dapper.Contar();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void TestDapper_InsertaArtistaTransaccion()
        {
            var artistid = _dapper.InsertArtistaTransaccion("prueba transaccion dapper");
            Assert.AreEqual(artistid > 0, true);
        }
    }
}

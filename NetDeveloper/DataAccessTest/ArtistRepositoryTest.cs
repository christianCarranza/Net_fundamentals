using DataAccess;
using DataAccess.AdoNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Linq;

namespace DataAccessTest
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        private ArtistRepository _adonet;

        public ArtistRepositoryTest()
        {
            _adonet = new ArtistRepository(ConfigurationManager.ConnectionStrings["Chinookcnx"].ConnectionString);
        }

        [TestMethod]
        public void Test_Conexion_Artist_Cantidad()
        {
            var count = _adonet.Contar();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void Test_BuscarPorId()
        {
            var artista = _adonet.GetArtistPorId(1);
            var artistaencontrado = new Artist
            {
                Artistid = 1,
                Name = "AC/DC"
            };
            Assert.AreEqual(artistaencontrado.Artistid, artista.Artistid);
            Assert.AreEqual(artistaencontrado.Name, artista.Name);
        }

        [TestMethod]
        public void Test_ListarArtista()
        {
            var listaartista = _adonet.GetListaArtista();
            Assert.AreEqual(listaartista.Count() > 0, true);
        }

        [TestMethod]
        public void Test_InsertarArtista()
        {
            var artistid = _adonet.InsertArtista("prueba");
            Assert.AreEqual(artistid > 0, true);
        }

        [TestMethod]
        public void InsertArtistaTransaction()
        {
            //var artistid = _adonet.InsertArtistaTransaction("prueba transaccion");
            //Assert.AreEqual(artistid > 0, true);
        }

    }
}

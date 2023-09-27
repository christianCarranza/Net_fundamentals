using DataAccess.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTest
{
    [TestClass]
    public class EFArtistRepositoryTest
    {
        private readonly ArtistRepository _entity;

        public EFArtistRepositoryTest()
        {
            _entity = new ArtistRepository();
        }

        [TestMethod]
        public void TestEF_Conexion_Artist_Cantidad()
        {
            var count  = _entity.Count();
            Assert.AreEqual(count > 0, true) ;
        }
    }
}

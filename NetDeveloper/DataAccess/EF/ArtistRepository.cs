using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EF
{
    public class ArtistRepository
    {
        private ChinookContext _context;

        public ArtistRepository()
        {
            _context = new ChinookContext();
        }

        public int Count()
        {
            return _context.Artists.Count();
        }

        public IEnumerable<Artist> GetListaArtista()
        {
            return _context.Artists;
        }

        public Artist GetArtist(int id)
        {
            return _context.Artists.FirstOrDefault(x=>x.Artistid==id);
        }

        public int InsertArtista(string name)
        {
            var artist = new Artist();
            artist.Name = name;
            _context.Artists.Add(artist);
            return _context.SaveChanges();
        }

        public int DeleteArtistaPorId(int id)
        {
            var artist = new Artist { Artistid = id };
            _context.Artists.Remove(artist);
            return _context.SaveChanges();
        }
    }
}

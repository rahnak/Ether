using Ether.Data.Dapper.SQLite.Repository;
using Ether.Data.Interfaces;

namespace Ether.Data.Dapper.SQLite
{
    public class DB : IRepository
    {
        private readonly string connectionString;

        public IAnimeRepository Animes => new AnimeRepository(connectionString);

        public IMangaRepository Mangas => new MangaRepository(connectionString);

        public ITvShowRepository TvShows => new TvShowRepository(connectionString);

        public DB(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
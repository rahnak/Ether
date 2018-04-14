namespace Ether.Data.Interfaces
{
    public interface IRepository
    {
        IAnimeRepository Animes { get; }
        IMangaRepository Mangas { get; }
        ITvShowRepository TvShows { get; }
    }
}
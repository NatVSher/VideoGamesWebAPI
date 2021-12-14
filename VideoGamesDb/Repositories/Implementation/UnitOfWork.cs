using System;
using VideoGamesDb.Models;
using VideoGamesDb.Repositories.Interfaces;

namespace VideoGamesDb.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext dataBase;
        private VideoGamesRepository videoGamesRepository;
        private GenresRepository genresRepository;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            dataBase = databaseContext;
        }       

        public IRepository<VideoGame> VideoGames
        {
            get
            {
                if (videoGamesRepository == null)
                    videoGamesRepository = new VideoGamesRepository(dataBase);
                return videoGamesRepository;
            }
        }
        public IRepository<Genre> Genres
        {
            get
            {
                if (genresRepository == null)
                    genresRepository = new GenresRepository(dataBase);
                return genresRepository;
            }
        }
        public void  SaveChanges()
        {
            dataBase.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataBase.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
               
    }
}

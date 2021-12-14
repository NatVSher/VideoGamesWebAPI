using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDb.Models;

namespace VideoGamesDb.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<VideoGame> VideoGames { get; }
        IRepository<Genre> Genres { get; }
        void SaveChanges();
    }
}

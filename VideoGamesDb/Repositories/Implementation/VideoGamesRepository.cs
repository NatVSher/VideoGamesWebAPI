using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDb.Models;
using VideoGamesDb.Repositories.Interfaces;

namespace VideoGamesDb.Repositories.Implementation
{
    public class VideoGamesRepository : IRepository<VideoGame>
    {
        private readonly DatabaseContext dataBase;

        public VideoGamesRepository(DatabaseContext databaseContext)
        {
            dataBase = databaseContext;
        }

        public void Create(VideoGame item)
        {
            if (item != null)
                dataBase.VideoGames.Add(item);            
        }

        public void Delete(int id)
        {
            VideoGame videoGame  = dataBase.VideoGames.Find(id);
            if (videoGame != null)
                dataBase.VideoGames.Remove(videoGame);            
        }

        public VideoGame FindById(int id)
        {
            return dataBase.VideoGames.Find(id);
        }

        public List<VideoGame> FindByName(string name)
        {
            return dataBase.VideoGames.Where(videoGame => videoGame.Name.ToLower().Contains(name.ToLower())).ToList();
        }        

        public List<VideoGame> GetAll()
        {
            return dataBase.VideoGames.Include(x => x.Genres).ToList();
        }

        public void Update(VideoGame item)
        {
            if (item != null)
                dataBase.Entry(item).State = EntityState.Modified;
        }               
    }
}

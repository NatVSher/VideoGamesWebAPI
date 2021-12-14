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
    public class GenresRepository : IRepository<Genre>
    {
        private readonly DatabaseContext dataBase;

        public GenresRepository(DatabaseContext databaseContext)
        {
            dataBase = databaseContext;
        }

        public void Create(Genre item)
        {
            dataBase.Genres.Add(item);
            dataBase.SaveChanges();
        }

        public void Delete(int id)
        {
            Genre genre = dataBase.Genres.Find(id);
            if (genre != null)
                dataBase.Genres.Remove(genre);
            dataBase.SaveChanges();
        }

        public Genre FindById(int id)
        {
            return dataBase.Genres.Find(id);
        }

        public List<Genre> FindByName(string name)
        {
            return dataBase.Genres.Where(genre => genre.Name.ToLower() == name.ToLower()).ToList();
        }

        public List<Genre> GetAll()
        {
            return dataBase.Genres.ToList();
        }

        public void Update(Genre item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
            
        }
    }
}

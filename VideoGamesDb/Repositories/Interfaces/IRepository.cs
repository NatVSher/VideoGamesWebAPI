using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesDb.Models;

namespace VideoGamesDb.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {        
        List<T> GetAll();
        T FindById(int id);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        List<T> FindByName(string name);
    }
}

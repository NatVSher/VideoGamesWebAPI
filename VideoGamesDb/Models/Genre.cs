using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesDb.Models
{
    public class Genre
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public List<VideoGame> VideoGames { get; init; } = new List<VideoGame>();
        public Genre(String name)
        {
            Name = name;
        }
        public Genre(int id, String name)
        {
            Id = id;
            Name = name;
        }
    }
}

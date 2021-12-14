using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesDb.Models
{
    public class VideoGame
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string DeveloperStudio { get; init; }
        public List<Genre> Genres { get; init; }

        public VideoGame(int id, string name, string developerStudio) : this(name, developerStudio)
        {
            Id = id;
        }
        public VideoGame( string name, string developerStudio) : this()
        {            
            Name = name;
            DeveloperStudio = developerStudio;            
        }
        public VideoGame()
        {
            Genres  = new List<Genre>();
        }
    }
}

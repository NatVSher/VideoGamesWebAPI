using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGamesWebAPI.Models
{
    public class VideoGameViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string DeveloperStudio { get; init; }
        public List<GenreViewModel> Genres { get; init; }

        public VideoGameViewModel(int id, string name, string developerStudio, List<GenreViewModel> genres)
        {
            Id = id;
            Name = name;
            DeveloperStudio = developerStudio;
            Genres = genres;
        }

        public VideoGameViewModel()
        {
            Genres = new List<GenreViewModel>();
        }
    }
}

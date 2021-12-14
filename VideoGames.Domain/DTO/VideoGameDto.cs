using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.Domain.DTO
{
    public class VideoGameDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string DeveloperStudio { get; init; }
        public List<GenreDto> Genres { get; init; }
        public VideoGameDto(int id, string name, string developerStudio, List<GenreDto> genres) : this()
        {
            Id = id;
            Name = name;
            DeveloperStudio = developerStudio;
            Genres = genres;
        }
        public VideoGameDto()
        {
            Genres = new List<GenreDto>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.Domain.DTO;

namespace VideoGames.Domain.Interfaces
{
    public interface IVideoGameService
    {
        List<VideoGameDto> GetVideoGamesByGenre(string genreName);
        void VideoGameAddGenre(int videoGameId, string genreName);
        void AddVideoGame(VideoGameDto videoGameDto);
        void AddGenre(GenreDto genreDto);
        List<VideoGameDto> GetVideoGames();
        List<GenreDto> GetGenres();
        void RemoveVideoGame(int id);
    }
}

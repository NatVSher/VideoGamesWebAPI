using System;
using System.Collections.Generic;
using System.Linq;
using VideoGames.Domain.DTO;
using VideoGames.Domain.Interfaces;
using VideoGamesDb.Models;
using VideoGamesDb.Repositories.Interfaces;

namespace VideoGames.Domain.Services
{
    public class VideoGameService : IVideoGameService
    {
        IUnitOfWork dataBase;
        public VideoGameService(IUnitOfWork unitOfWork)
        {
            dataBase = unitOfWork;
        }
        public List<VideoGameDto> GetVideoGamesByGenre(string genreName)
        {
            if (genreName != null)
            {
                Genre genre = dataBase.Genres.FindByName(genreName).FirstOrDefault();

                if (genre == null)
                    throw new ArgumentException("Такой жанр не найден");

                var videoGames = dataBase.VideoGames.GetAll()
                    .Where(videoGame => videoGame.Genres.Contains(genre))
                    .Select(v => new VideoGameDto
                    {
                        Id = v.Id,
                        Name = v.Name,
                        DeveloperStudio = v.DeveloperStudio,
                        Genres = v.Genres.Select(g => new GenreDto() { Id = g.Id, Name = g.Name }).ToList()
                    })
                    .ToList();
                return videoGames;
            }
            else
                throw new ArgumentNullException("Нужно указать жанр");
        }
        public void VideoGameAddGenre(int videoGameId, string genreName)
        {
            if (genreName != null)
            {
                Genre genre = dataBase.Genres.FindByName(genreName).FirstOrDefault();
                if (genre == null)
                    throw new ArgumentException("Такой жанр не найден");
                var videoGames = dataBase.VideoGames.FindById(videoGameId);
                if (videoGames == null)
                    throw new ArgumentException("Такой игры не существует");
                videoGames.Genres.Add(genre);
                dataBase.VideoGames.Update(videoGames);
                dataBase.SaveChanges();
            }
            else
                throw new ArgumentNullException();
        }
        public void AddVideoGame(VideoGameDto videoGameDto)
        {
            if (videoGameDto != null)
            {
                var videoGame = new VideoGame
                {
                    Name = videoGameDto.Name,
                    DeveloperStudio = videoGameDto.DeveloperStudio,
                    Genres = videoGameDto.Genres.Select(g => dataBase.Genres.FindById(g.Id)).ToList()
                };
                if (videoGame.Genres.Where(g => g is null).ToArray().Length == 0)
                {
                    dataBase.VideoGames.Create(videoGame);
                    dataBase.SaveChanges();
                }
                else
                    throw new ArgumentException("Такого жанра не существует");
            }
            else
                throw new ArgumentNullException();
        }
        public void AddGenre(GenreDto genreDto)
        {
            if (genreDto != null)
            {
                var genre = new Genre(genreDto.Name);
                dataBase.Genres.Create(genre);
                dataBase.SaveChanges();
            }
            else
                throw new ArgumentNullException();
        }
        public List<GenreDto> GetGenres()
        {
            var genres = dataBase.Genres.GetAll()
                .Select(v => new GenreDto
                {
                    Id = v.Id,
                    Name = v.Name
                })
                .ToList();
            return genres;
        }
        public List<VideoGameDto> GetVideoGames()
        {
            var videoGames = dataBase.VideoGames.GetAll()
                .Select(v => new VideoGameDto
                {
                    Id = v.Id,
                    Name = v.Name,
                    DeveloperStudio = v.DeveloperStudio,
                    Genres = v.Genres.Select(g => new GenreDto() 
                    { 
                        Id = g.Id, 
                        Name = g.Name 
                    }).ToList()
                })
                .ToList();
            return videoGames;
        }
        public void RemoveVideoGame(int id)
        {
            if (dataBase.VideoGames.FindById(id) != null)
            {
                dataBase.VideoGames.Delete(id);
                dataBase.SaveChanges();
            }
            else
                throw new ArgumentException("Такая игра не существует");
        }
    }
}

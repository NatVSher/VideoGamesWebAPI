using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VideoGames.Domain.DTO;
using VideoGames.Domain.Interfaces;
using VideoGamesWebAPI.Models;

namespace VideoGamesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGameService _videoGameService;
        private readonly IMapper _mapper;
        public VideoGamesController(IMapper mapper, IVideoGameService videoGameService)
        {
            _mapper = mapper;
            _videoGameService = videoGameService;
        }

        [HttpGet]
        public ActionResult<List<VideoGameViewModel>> GetAll()
        {
            var videoGames = _videoGameService.GetVideoGames();
            return _mapper.Map<List<VideoGameViewModel>>(videoGames);
        }
        [HttpGet("/VideoGame/By/Genre")]
        public ActionResult<List<VideoGameViewModel>> GetByGenre(string genreName)
        {
            var videoGames = _videoGameService.GetVideoGamesByGenre(genreName);
            return _mapper.Map<List<VideoGameViewModel>>(videoGames);
        }
        [HttpPost("/create")]
        public ActionResult Create(VideoGameViewModel videoGameViewModel)
        {           
            if (ModelState.IsValid)
            {
                var videoGame = _mapper.Map<VideoGameDto>(videoGameViewModel);
                _videoGameService.AddVideoGame(videoGame);
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", "Данные не корректны.");
                return BadRequest("Данные не корректны.");
            }
        }
        [HttpPut("/videoGame/add/genre")]
        public ActionResult VideoGameAddGenre(int videoGameId, string genreName)
        {            
            _videoGameService.VideoGameAddGenre(videoGameId, genreName);
            return Ok();
        }
        [HttpDelete("/videoGame/{id}")]
        public ActionResult RemoveVideoGame(int id)
        {
            _videoGameService.RemoveVideoGame(id);
            return Ok();
        }
    }
}

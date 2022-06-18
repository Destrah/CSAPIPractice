
using Microsoft.AspNetCore.Mvc;
using CSAPIPractice.Repositories;
using CSAPIPractice.Entities;
using CSAPIPractice.DTOs;

namespace CSAPIPractice.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersRepository repository;

        public PlayersController(IPlayersRepository repository)
        {
            this.repository = repository;
        }

        //Defining a route to retrieve all the palyers
        [HttpGet]
        public IEnumerable<PlayerDTO> GetPlayers()
        {
            var players = repository.GetPlayers().Select( player => player.AsDto());
            return players;
        }

        // GET /palyers/{identifier}
        [HttpGet("{identifier}")]
        public ActionResult<PlayerDTO> GetPlayer(string identifier)
        {
            var player = repository.GetPlayer(identifier);

            if (player is null)
            {
                return NotFound();
            }

            return Ok(player.AsDto());
        }

        // POST /palyers
        [HttpPost]
        public ActionResult<PlayerDTO> AddPlayer(AddPlayerDTO playerDTO)
        {
            Player player = new(){
                Identifier = playerDTO.Identifier,
                FirstName = playerDTO.FirstName,
                LastName = playerDTO.LastName,
                Job = playerDTO.Job,
            };

            repository.AddPlayer(player);

            return CreatedAtAction(nameof(GetPlayer), new { identifier = player.Identifier }, player.AsDto());
        }

        // PUT /palyers/{identifier}
        [HttpPut("{identifier}")]
        public ActionResult UpdatePlayer(string identifier, UpdatePlayerDTO playerDTO)
        {
            var existingPlayer = repository.GetPlayer(identifier);

            if (existingPlayer is null)
            {
                return NotFound();
            }

            Player updatedPlayer = existingPlayer with
            {
                FirstName = playerDTO.FirstName,
                LastName = playerDTO.LastName,
                Job = playerDTO.Job
            };

            repository.UpdatePlayer(updatedPlayer);

            return NoContent();
        }

        // DELETE /palyers/{identifier}
        [HttpDelete("{identifier}")]
        public ActionResult RemovePlayer(string identifier)
        {
            var existingPlayer = repository.GetPlayer(identifier);

            if (existingPlayer is null)
            {
                return NotFound();
            }

            repository.RemovePlayer(identifier);

            return NoContent();
        }
        
    }
}
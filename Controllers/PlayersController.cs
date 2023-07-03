
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
            if (!(playerDTO is null)) {
                var tempPlayer = repository.GetPlayer(playerDTO.Identifier);

                if(tempPlayer is null) {
                    Player player = new(){
                        Identifier = playerDTO.Identifier,
                        FirstName = playerDTO.FirstName,
                        LastName = playerDTO.LastName,
                        Job = playerDTO.Job,
                        JobDuty = playerDTO.JobDuty,
                        ToggleStatus = playerDTO.ToggleStatus,
                        Rank = playerDTO.Rank
                    };
                    repository.AddPlayer(player);

                    return CreatedAtAction(nameof(GetPlayer), new { identifier = player.Identifier }, player.AsDto());
                } else {
                    return NotFound();
                }
            } else {
                return NotFound();
            }
        }

        // PUT /palyers/{identifier}
        [HttpPut("{identifier}")]
        public ActionResult UpdatePlayer(string identifier, UpdatePlayerDTO playerDTO)
        {
            var existingPlayer = repository.GetPlayer(identifier);

            Player updatedPlayer = existingPlayer with
            {
                Job = playerDTO.Job,
                JobDuty = playerDTO.JobDuty,
                ToggleStatus = playerDTO.ToggleStatus,
                Rank = playerDTO.Rank
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

        // DELETE /palyers
        [HttpDelete]
        public ActionResult RemoveAllPlayers()
        {
            repository.RemoveAllPlayers();
            
            return NoContent();
        }
        
    }
}
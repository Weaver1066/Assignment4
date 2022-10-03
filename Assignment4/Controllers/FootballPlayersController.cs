using Assignment1;
using Assignment4.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        public FootballPlayersController (FootballPlayersManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IEnumerable<FootballPlayer> Get(string substring, [FromHeader] int id)
        {
            return _manager.GetAll();
        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer footballPlayer = _manager.GetFootballPlayerById(id);
            if (footballPlayer == null) return NotFound("No Such player id: " + id);
            return Ok(footballPlayer);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            _manager.Add(value);
            return Created($"api/FootballPlayer/{value.id}", value);
        }
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            if (_manager.GetAll().Select(v => v.id).Contains(id))
            {
                _manager.Update(id, value);
                return Ok("Player Updated");
            }
            else
            {
                return NotFound();
            } 
            
        }
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer footballPlayer = _manager.GetFootballPlayerById(id);
            if(footballPlayer== null) return NotFound("No such Player id: " + id);
            _manager.Delete(id);
            return Ok("Player Deleted");
        }
    }
}
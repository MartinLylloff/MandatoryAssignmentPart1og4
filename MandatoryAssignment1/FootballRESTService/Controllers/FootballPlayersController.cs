using FootballRESTService.Managers;
using MandatoryAssignment1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballRESTService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        // GET: FootballPlayersController
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FootballPlayer>> Get()
        {
            var list = _manager.GetAll();
            if (list == null) return NotFound("No list was found");
            if (list.Count == 0) return NoContent();
            return Ok(_manager.GetAll());
        }

        // GET: FootballPlayersController/Details/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer player = _manager.GetById(id);
            if (player == null) return NotFound("No player was found");
            return Ok(player);
        }

        // POST: FootballPlayersController/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            try
            {
                value.Validate();
            }
            catch
            {
                return BadRequest("Data was not correct");
            }
            if (_manager.GetAll().Exists(va => va.ShirtNumber == value.ShirtNumber)) return Conflict("Shirtnumber already exist");
            _manager.Add(value);
            return Created("api/" + value.Id, value);
        }

        // PUT: FootballPlayersController/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            
            try
            {
                value.Validate();
            }
            catch
            {
                return BadRequest("Incorrect data");  
            }

            if(_manager.GetById(id).ShirtNumber != value.ShirtNumber && _manager.GetAll().Exists(player => player.ShirtNumber == value.ShirtNumber)) 
                return Conflict("A player with same shirtnumber already exists");
            return Ok(_manager.Update(id, value));  
        }

        // GET: FootballPlayersController/Delete/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer player = _manager.GetById(id);
            
            if (player == null) return NotFound($"No player with id: {id} was found");
            return Ok(player);
        }
    }
}

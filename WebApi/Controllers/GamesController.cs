using DBLibrary.Models;
using DBLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(GameRepository repository) : ControllerBase
    {
        private readonly GameRepository _repository = repository;

        // GET: api/<GamesController>
        [HttpGet]
        public IActionResult Get()
            => Ok(_repository.GetAll());

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
            =>  Ok(_repository.GetById(id));

        // POST api/<GamesController>
        [HttpPost]
        public IActionResult Post([FromBody] Game game) 
        {
            try
            {
                _repository.Create(game);
            }
            catch
            {
                return BadRequest();
            }

            return Created();
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Game game)
        {
            if(id != game.Id)
                return NotFound();

            try
            {
                _repository.Update(game);
            }
            catch
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}

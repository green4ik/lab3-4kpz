using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TeamFightTacticsReviewApp.Data;
using TeamFightTacticsReviewApp.Interface;
using TeamFightTacticsReviewApp.Models;
using TeamFightTacticsReviewApp.Repository;

namespace TeamFightTacticsReviewApp.Controllers {
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ChampionController : Controller {
        private readonly IChampionRepository championRepository;
        private readonly DataContext context;

        public ChampionController(IChampionRepository champRepository, DataContext context) {
            this.championRepository = champRepository;
            this.context = context;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Champion>))]
        public IActionResult GetChampions() {
            var champs = championRepository.GetChampions();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(champs);

        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Champion))]
        public IActionResult GetChampion(int id) {
            if(!championRepository.ChampionExists(id))
                return NotFound();
            var champ = championRepository.GetChampion(id);
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(champ);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateChampion([FromBody] Champion tacticCreate) {
            if (tacticCreate == null)
                return BadRequest(ModelState);
            /*var tactic = tacticRepository.GetTactics().Where(t => t.Name.Trim().ToUpper() == tacticCreate.Name.TrimEnd().ToUpper());
            if (tactic != null) {
                ModelState.AddModelError("", "tactic exists");
                return StatusCode(422, ModelState);
            }*/
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (!championRepository.CreateChampion(tacticCreate)) {
                ModelState.AddModelError("", "smth went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Created!");

        }
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public IActionResult UpdateChampion([FromBody] Champion championUpdate, int id) {
            if (championUpdate == null)
                return BadRequest(ModelState);
            if (id != championUpdate.Id)
                return BadRequest(ModelState);
            if (!championRepository.UpdateChampion(championUpdate)) {
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public IActionResult DeleteChampion(int id) {
            if (!championRepository.ChampionExists(id)) {
                return NotFound();
            }
            var tactic = championRepository.GetChampion(id);
            if (!championRepository.DeleteChampion(tactic))
                return BadRequest(ModelState);
            return Ok();
        }
    }
}

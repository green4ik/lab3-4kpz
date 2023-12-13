
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using TeamFightTacticsReviewApp.Data;
using TeamFightTacticsReviewApp.Interface;
using TeamFightTacticsReviewApp.Models;

namespace TeamFightTacticsReviewApp.Controllers {
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TacticController : Controller{
        private readonly ITacticRepository tacticRepository;
        private readonly DataContext context;

        public TacticController(ITacticRepository tacticRepository, DataContext context)
        {
            this.tacticRepository = tacticRepository;
            this.context = context;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Tactic>))]
        public IActionResult GetTactics() {
            var tactics = tacticRepository.GetTactics();

            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }else return Ok(tactics);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200,Type = typeof(Tactic))]
        public IActionResult GetTactic(int id) {

            if (!tacticRepository.TacticExists(id))
                return NotFound();
            var tactic = tacticRepository.GetTactic(id);
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(tactic);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateTactic([FromBody] Tactic tacticCreate) {
            if(tacticCreate == null)
                return BadRequest(ModelState);
            /*var tactic = tacticRepository.GetTactics().Where(t => t.Name.Trim().ToUpper() == tacticCreate.Name.TrimEnd().ToUpper());
            if (tactic != null) {
                ModelState.AddModelError("", "tactic exists");
                return StatusCode(422, ModelState);
            }*/
            if(!ModelState.IsValid)
                { return BadRequest(ModelState); }
            if(!tacticRepository.CreateTactic(tacticCreate)) {
                ModelState.AddModelError("", "smth went wrong");
                return StatusCode(500,ModelState);
            }
            return Ok("Created!");

        }
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public IActionResult UpdateTactic([FromBody] Tactic tacticUpdate,int id) {
            if (tacticUpdate == null)
                return BadRequest(ModelState);
            if(id != tacticUpdate.Id)
                return BadRequest(ModelState);
            if(!tacticRepository.UpdateTactic(tacticUpdate)) {
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public IActionResult DeleteTactic(int id) {
            if(!tacticRepository.TacticExists(id)) {
                return NotFound();
            }
            var tactic = tacticRepository.GetTactic(id);
            if(!tacticRepository.DeleteTactic(tactic))
                return BadRequest(ModelState);
            return Ok();
        }
    }
}

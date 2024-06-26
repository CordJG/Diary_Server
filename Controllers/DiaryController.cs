using Diary_Server.Dtos.Diarys;
using Diary_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Diary_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiaryController : ControllerBase
    {
        private readonly IDiaryService _diaryService;

        public DiaryController(IDiaryService diaryService)
        {
            _diaryService = diaryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DiaryDto>> GetEntries()
        {
            var userId = User.Identity.Name; // Assuming user identity is set
            var entries = _diaryService.GetEntries(userId);
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public ActionResult<DiaryDto> GetEntry(int id)
        {
            var userId = User.Identity.Name; // Assuming user identity is set
            var entry = _diaryService.GetEntry(id, userId);
            if (entry == null)
                return NotFound();
            return Ok(entry);
        }

        [HttpPost]
        public ActionResult<DiaryDto> CreateEntry([FromBody] CreateDiaryDto entryDto)
        {
            var userId = User.Identity.Name; // Assuming user identity is set
            var entry = _diaryService.CreateEntry(userId, entryDto);
            return CreatedAtAction(nameof(GetEntry), new { id = entry.Id }, entry);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEntry(int id)
        {
            var userId = User.Identity.Name; // Assuming user identity is set
            _diaryService.DeleteEntry(id, userId);
            return NoContent();
        }
    }
}

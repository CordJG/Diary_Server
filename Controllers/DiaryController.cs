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
        public ActionResult<IEnumerable<DiaryDto>> GetDiarys()
        {

            return Ok(_diaryService.GetDiarys());
        }

        [HttpGet("{userId}")]
        public ActionResult<DiaryDto> GetUserDiarys(long userId)
        {
            var entry = _diaryService.GetUserDiarys(userId);
            if (entry == null)
                return NotFound();
            return Ok(entry);
        }

        [HttpPost]
        public ActionResult<DiaryDto> CreateEntry([FromBody] CreateDiaryDto entryDto)
        {
            var entry = _diaryService.CreateEntry( entryDto);
            return Ok(entry);
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteEntry(long userId)
        {
            _diaryService.DeleteEntry(userId);
            return NoContent();
        }
    }
}

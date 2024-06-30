using Diary_Server.Dtos.Diarys;
using Diary_Server.Interface;
using Diary_Server.Security;
using Diary_Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diary_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DiaryController : ControllerBase
    {
        private readonly IDiaryService _diaryService;

        public DiaryController(IDiaryService diaryService)
        {
            _diaryService = diaryService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DiaryDto>> GetAllDiaries()
        {
            var diaries = _diaryService.GetAllDiarys();
            return Ok(diaries);
        }

        [HttpGet("{id}")]
        public ActionResult<DiaryDto> GetDiary(long id)
        {
            var diary = _diaryService.GetDiary(id);
            return Ok(diary);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<DiaryDto>> GetUserDiaries(long userId)
        {
            var loginUserId = User.GetUserId();
            var diaries = _diaryService.GetUserDiarys(userId, loginUserId);
            return Ok(diaries);
        }

        [HttpPost]
        public ActionResult<DiaryDto> CreateDiary(CreateDiaryDto createDiaryDto)
        {

            var diary = _diaryService.CreateEntry(createDiaryDto);
            return CreatedAtAction(nameof(GetUserDiaries), new { userId = createDiaryDto.UserId }, diary);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDiary(long id, UpdateDiaryDto updateDiaryDto)
        {
            var loginUserId = User.GetUserId();
            _diaryService.UpdateEntry(id, updateDiaryDto, loginUserId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiary(long id)
        {
            var loginUserId = User.GetUserId();
            _diaryService.DeleteEntry(id, loginUserId);
            return NoContent();
        }
    }
}

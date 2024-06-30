using Diary_Server.Dtos.Diarys;

namespace Diary_Server.Interface
{
    public interface IDiaryService
    {
        IEnumerable<DiaryDto> GetAllDiarys();

        DiaryDto GetDiary(long id);
        IEnumerable<DiaryDto> GetUserDiarys(long userId, long loginUserId);
        DiaryDto CreateEntry(CreateDiaryDto entry);

        void UpdateEntry(long diaryId, UpdateDiaryDto updateDto, long loginUserId);
        void DeleteEntry(long userId, long loginUserId);
    }
}

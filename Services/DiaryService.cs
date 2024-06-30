using AutoMapper;
using Diary_Server.Dtos.Diarys;
using Diary_Server.Interface;
using Diary_Server.Models;


namespace Diary_Server.Services
{
    public class DiaryService : IDiaryService
    {
        private readonly IDiaryContextHandler _diaryContextHandler;
        private readonly IUserContextHandler _userContextHandler;
        private readonly IMapper _mapper;

        public DiaryService(IDiaryContextHandler diaryContextHandler, IUserContextHandler userContextHandler, IMapper mapper)
        {
            _diaryContextHandler = diaryContextHandler;
            _userContextHandler = userContextHandler;
            _mapper = mapper;
        }

        public IEnumerable<DiaryDto> GetAllDiarys()
        {
            var diarys = _diaryContextHandler.GetAll();
            return _mapper.Map<List<DiaryDto>>(diarys);
        }

        public DiaryDto GetDiary(long id)
        {
            var diary = _diaryContextHandler.GetById(id);
            return _mapper.Map<DiaryDto>(diary);
        }

        public IEnumerable<DiaryDto> GetUserDiarys(long userId, long loginUserId)
        {
            var diaries = _diaryContextHandler.GetUserDiaries(userId, loginUserId);
            return _mapper.Map<List<DiaryDto>>(diaries);
        }

        public DiaryDto CreateEntry(CreateDiaryDto entryDto)
        {
            var user = _userContextHandler.GetById(entryDto.UserId);
            if (user == null) return null;


            var newEntry = _mapper.Map<Diary>(entryDto);

            newEntry.User = user;
            newEntry.CreatedAt = DateTime.UtcNow;
            newEntry.UpdatedAt = DateTime.UtcNow;

            user.Diaries.Add(newEntry);

            _diaryContextHandler.Add(newEntry);

            return _mapper.Map<DiaryDto>(newEntry);
        }

        public void UpdateEntry(long diaryId, UpdateDiaryDto updateDto, long loginUserId)
        {
            var diary = _diaryContextHandler.GetById(diaryId);
            if (diary == null)
            {
                throw new KeyNotFoundException("Diary entry not found");
            }
            if (diary.UserId != loginUserId)
            {
                throw new UnauthorizedAccessException("You do not have permission to update this diary entry");
            }

            _mapper.Map(updateDto, diary);
            diary.UpdatedAt = DateTime.UtcNow;
            _diaryContextHandler.Update(diary);
        }

        public void DeleteEntry(long diaryId, long loginUserId)
        {
            var diary = _diaryContextHandler.GetById(diaryId);
            if (diary == null)
            {
                throw new KeyNotFoundException("Diary entry not found");
            }
            if (diary.UserId != loginUserId)
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this diary entry");
            }

            _diaryContextHandler.Delete(diary);
        }
    }
}

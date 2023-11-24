using MeetingApp.BusinessLayer.Service;
using MeetingApp.DataLayer.Interface;
using MeetingApp.Models.Entities;

namespace MeetingApp.BusinessLayer.Manager
{
    public class MeetingManager : IMeetingService
    {
        IMeetingRepository _repo;

        public MeetingManager(IMeetingRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Meeting>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<Meeting> TGetByIdAsync(int id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task TAddAsync(Meeting entity)
        {
            return _repo.AddAsync(entity);
        }

        public Task TUpdateAsync(Meeting entity)
        {
            return _repo.UpdateAsync(entity);
        }

        public Task TDeleteAsync(int id)
        {
            return _repo.DeleteAsync(id);
        }

        public Task<IEnumerable<Meeting>> GetMeetingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return _repo.GetMeetingsByDateRangeAsync(startDate, endDate);
        }
    }

}

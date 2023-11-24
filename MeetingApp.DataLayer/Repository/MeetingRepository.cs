using MeetingApp.DataLayer.Interface;
using MeetingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.DataLayer.Repository
{
    public class MeetingRepository : GenericRepository<Meeting>, IMeetingRepository
    {
       
        private readonly AppDbContext _appDbContext;

        public MeetingRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(Meeting m)
        {
            _appDbContext.Update(m);
        }

        public IEnumerable<Meeting> GetMeetingsByDateRange(DateTime startDate, DateTime endDate)
        {
            // Belirtilen tarih aralığındaki toplantıları getir
            return _appDbContext.Meetings
                .Where(meeting => meeting.StartTime >= startDate && meeting.EndTime <= endDate)
                .ToList();
        }

    }

}

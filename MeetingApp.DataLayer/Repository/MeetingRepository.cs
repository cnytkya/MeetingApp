using MeetingApp.DataLayer.Interface;
using MeetingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.DataLayer.Repository
{
    public class MeetingRepository : GenericRepository<Meeting>, IMeetingRepository
    {
        public MeetingRepository(AppDbContext context) : base(context)
        {
            // Eğer Meeting ile ilgili özel işlemler eklemek istiyorsanız, buraya ekleyebilirsiniz.
        }

        public async Task<IEnumerable<Meeting>> GetMeetingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet.Where(m => m.StartTime >= startDate && m.EndTime <= endDate).ToListAsync();
        }
    }

}

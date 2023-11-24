using MeetingApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.DataLayer.Interface
{
    public interface IMeetingRepository : IGenericRepository<Meeting>
    {
        // Özel toplantı ile ilgili metot.
        Task<IEnumerable<Meeting>> GetMeetingsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }

}

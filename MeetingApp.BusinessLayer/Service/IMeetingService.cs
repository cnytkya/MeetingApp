using MeetingApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.BusinessLayer.Service
{
    public interface IMeetingService : IGenericService<Meeting>
    {
        Task<IEnumerable<Meeting>> GetMeetingsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }

}

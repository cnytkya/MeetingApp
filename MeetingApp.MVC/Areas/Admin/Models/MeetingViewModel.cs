using MeetingApp.Models.Entities;

namespace MeetingApp.WebUI.Areas.Admin.Models
{
    public class MeetingViewModel
    {
        public IEnumerable<Meeting> Meetings { get; set; }
    }
}

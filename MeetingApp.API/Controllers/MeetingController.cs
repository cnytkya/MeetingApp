using MeetingApp.DataLayer.Interface;
using MeetingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingRepository _mRepo;

        public MeetingController(IMeetingRepository mRepo)
        {
            _mRepo = mRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Meeting>> GetMeetings()
        {
            var meetings = _mRepo.GetAll().ToList();
            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public ActionResult<Meeting> GetMeetingById(int id)
        {
            var meeting = _mRepo.Get(x => x.Id == id);

            if (meeting == null)
            {
                return NotFound();
            }

            return Ok(meeting);
        }

        [HttpPost]
        public ActionResult<Meeting> CreateMeeting(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _mRepo.Add(meeting);
                _mRepo.Save();
                return CreatedAtAction(nameof(GetMeetingById), new { id = meeting.Id }, meeting);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeeting(int id, Meeting meeting)
        {
            if (id != meeting.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _mRepo.Update(meeting);
                _mRepo.Save();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeeting(int id)
        {
            var meeting = _mRepo.Get(x => x.Id == id);

            if (meeting == null)
            {
                return NotFound();
            }

            _mRepo.Remove(meeting);
            _mRepo.Save();

            return NoContent();
        }
    }
}
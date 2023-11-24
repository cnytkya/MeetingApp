using Microsoft.AspNetCore.Mvc;
using MeetingApp.DataLayer.Interface;
using MeetingApp.Models.Entities;

namespace MeetingApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository _mRepo;

        public MeetingController(IMeetingRepository mRepo)
        {
            _mRepo = mRepo;
        }

        //private readonly MeetingManager _manager;


        public IActionResult Index(int id)
        {
            List<Meeting> categories = _mRepo.GetAll().ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Meeting meeting)
        {

            if (ModelState.IsValid)
            {
                _mRepo.Add(meeting);
                _mRepo.Save();
                TempData["success"] = "Toplantı başarıyla oluşturuldu.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Meeting meeting =  _mRepo.Get(x => x.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        [HttpPost]
        public IActionResult Edit(int id, Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _mRepo.Update(meeting);
                _mRepo.Save();
                TempData["success"] = "Toplantı başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Meeting meeting = _mRepo.Get(x => x.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Meeting? meeting = _mRepo.Get(x => x.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            _mRepo.Remove(meeting);
            _mRepo.Save();
            TempData["success"] = "Toplantı başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}

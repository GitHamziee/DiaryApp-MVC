using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Controllers
{
    public class DiaryEntryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DiaryEntryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();
            return View(objDiaryEntryList);
        }

        public IActionResult CreateEntry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEntry(DiaryEntry obj)
        {
            if (obj != null )
            {
                _db.DiaryEntries.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
            
        }
        [HttpGet]
        public IActionResult EditDiary(int? id)
        {

            if (id == 0 && id == null )
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry); 
        }
        [HttpPost]
        public IActionResult EditDiary(DiaryEntry obj)
        {
            if (obj != null)
            {
                _db.DiaryEntries.Update(obj);
                _db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }




        [HttpGet]
        public IActionResult DeleteEntry(int? id)
        {

            if (id == 0 && id == null)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        public IActionResult DeleteEntry(DiaryEntry obj)
        {
            if (obj != null)
            {
                _db.DiaryEntries.Remove(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                return View(obj);
            }

        }

    }
}

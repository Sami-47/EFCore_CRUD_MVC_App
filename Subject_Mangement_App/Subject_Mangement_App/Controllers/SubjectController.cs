using Microsoft.AspNetCore.Mvc;
using Subject_Mangement_App.Context;
using Subject_Mangement_App.Models;

namespace Subject_Mangement_App.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SubjectContext db;

        public SubjectController(SubjectContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            IEnumerable<Subject> subjects = db.Subjects.Select(s => s).ToList();
            return View(subjects);
        }

        public IActionResult Details()
        {
            IEnumerable<Subject> subjects = db.Subjects.Select(s => s).ToList();
            return View(subjects);
        }

        public IActionResult Delete( int id)
        {
            Subject subject = db.Subjects.FirstOrDefault(s => s.SubjectId == id);
            if(subject != null)
            {
                db.Remove(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        public async Task<IActionResult> Create(Subject subject)
        {
            if (!subject.Equals(null))
            {
                var subjects = new Subject();
                subjects.SubjectId = subject.SubjectId;
                subjects.SubjectName = subject.SubjectName;
                subjects.SubjectTerm = subject.SubjectTerm;
                subjects.Teachers = subject.Teachers;

                db.Add(subjects);
                await db.SaveChangesAsync();

                return View(subjects);


            }
            
            return View();
        }

        public IActionResult Edit(int id)
        {
            var subj = db.Subjects.Where(s=> s.SubjectId == id).FirstOrDefault();
            return View(subj);
            
        }
        [HttpPost]
        public IActionResult Edit(Subject subjects)
        {
            var subj = db.Subjects.Where(s => s.SubjectId == subjects.SubjectId).FirstOrDefault();
            if(subj != null)
            {
                db.Subjects.Remove(subj);
                db.Subjects.Add(subjects);
                db.SaveChanges();


                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }
    }
}

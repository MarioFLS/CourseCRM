using CourseCRM.Models;
using CourseCRM.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseCRM.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly CourseContext _context;

        public EnrollmentsController(CourseContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var courseContext = _context.Enrollment.Include(e => e.Course).Include(e => e.Lead);
            return View(await courseContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Lead)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }


        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name");
            ViewData["LeadId"] = new SelectList(_context.Leads, "Id", "Email");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,LeadId,Registration")] Enrollment enrollment)
        {
            try
            {
                enrollment.Lead = _context.Leads.Where(l => l.Id == enrollment.LeadId).FirstOrDefault();
                enrollment.Course = _context.Course.Where(l => l.Id == enrollment.CourseId).FirstOrDefault();
                if (ModelState.IsValid)
                {
                    _context.Enrollment.Add(enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", enrollment.CourseId);
                ViewData["LeadId"] = new SelectList(_context.Leads, "Id", "Email", enrollment.LeadId);
                return View(enrollment);
            }
            catch (Exception)
            {

                TempData["MensagemErro"] = $"Não foi possível realizar a Matrícula, tente novamante!" +
                    $"\nVocê provavelmente está tentando matricular um Aluno em uma matéria a qual ele já está matriculado!";
                ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", enrollment.CourseId);
                ViewData["LeadId"] = new SelectList(_context.Leads, "Id", "Email", enrollment.LeadId);
                return View(enrollment);
            }

        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", enrollment.CourseId);
            ViewData["LeadId"] = new SelectList(_context.Leads, "Id", "Email", enrollment.LeadId);
            return View(enrollment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,LeadId,Registration")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", enrollment.CourseId);
            ViewData["LeadId"] = new SelectList(_context.Leads, "Id", "Email", enrollment.LeadId);
            return View(enrollment);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Lead)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enrollment == null)
            {
                return Problem("Entity set 'CourseContext.Enrollment'  is null.");
            }
            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollment.Remove(enrollment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}

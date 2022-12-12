using CourseCRM.Models;
using CourseCRM.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseCRM.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseContext _context;

        public CourseController(CourseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Course.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Course.Add(course);
                    await _context.SaveChangesAsync();

                    TempData["MensagemSucesso"] = "Curso Criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }

                return View(course);
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = $"Não foi possível criar seu curso, tente novamante!" +
                   $"\nProvavelmente está tentando criar um Curso com nome já existente!";
                return View(course);
            }

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Course course)
        {
            try
            {
                if (id != course.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Course.Update(course);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CourseExists(course.Id))
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
                return View(course);
            }
            catch (Exception)
            {

                TempData["MensagemErro"] = $"Não foi possível editar seu curso, tente novamante!" +
                   $"\nProvavelmente está tentando colocar um nome já existente!";
                return View(course);
            }   
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Course == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Course == null)
            {
                return Problem("Entity set 'CourseContext.Course'  is null.");
            }
            var course = await _context.Course.FindAsync(id);
            if (course != null)
            {
                _context.Course.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }
    }
}

using CourseCRM.Models;
using CourseCRM.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseCRM.Controllers
{
    public class LeadController : Controller
    {

        private readonly ICourseRepository _courseRepository;

        public LeadController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Lead? lead = _courseRepository.GetLeadAndEnrollment(id);
            if (lead == null)
            {
                return NotFound();
            }
            return View(lead);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,Cpf")] Lead lead)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    lead = _courseRepository.CreateLeader(lead);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }

                return View(lead);
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar seu usuário, tente novamante!" +
                    $"\nProvavelmente já existe um estudante com esse Email ou CPF!";
                return View(lead);
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Lead? lead = _courseRepository.GetLead(id);
            return View(lead);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind("Id,Email,Name,Cpf")] Lead lead)
        {
            try
            {
                if (id != lead.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _courseRepository.EditLeader(lead);
                        return RedirectToAction("Index", "Home");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!_courseRepository.LeadExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return View(lead);
                }

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, errors = ModelState.Values.Where(i => i.Errors.Count > 0) });
                }
                return View(lead);
            }
            catch (Exception)
            {

                TempData["MensagemErro"] = $"Não foi possível editar seu curso, tente novamante!" +
                   $"\nProvavelmente está Registrar dados iguais";
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lead? lead = _courseRepository.GetLead(id);
            if (lead == null)
            {
                return NotFound();
            }

            return View(lead);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lead? lead = _courseRepository.GetLead(id);
            if (lead != null)
            {
                _courseRepository.DeleteLeader(lead);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

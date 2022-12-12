using CourseCRM.Models;
using CourseCRM.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseCRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public HomeController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            List<Lead> leads = _courseRepository.GetAllLeads();
            return View(leads);
        }

        public IActionResult CreateLeader()
        {
            return View("~/Views/Lead/CreateLeader.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLeader(Lead lead)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    lead = _courseRepository.CreateLeader(lead);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("~/Views/Lead/CreateLeader.cshtml", lead);
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar seu usuário, tente novamante!" +
                    $"\nProvavelmente já existe um estudante com esse Email ou CPF!";
                return View("~/Views/Lead/CreateLeader.cshtml", lead);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
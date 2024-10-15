// Controllers/ProfesionsController.cs
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repositories;
using personapi_dotnet.Models.ViewModels;
namespace personapi_dotnet.Controllers
{
    public class ProfesionsController : Controller
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionsController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        // GET: Profesions
        public async Task<IActionResult> Index()
        {
            return View(await _profesionRepository.GetAllProfesionsAsync());
        }

        // GET: Profesions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var profesion = await _profesionRepository.GetProfesionByIdAsync(id.Value);
            if (profesion == null) return NotFound();

            return View(profesion);
        }

        // GET: Profesions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfesionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var profesion = new Profesion { Id = model.Id, Nom = model.Nom, Des = model.Des };
                await _profesionRepository.AddProfesionAsync(profesion);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Profesions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var profesion = await _profesionRepository.GetProfesionByIdAsync(id.Value);
            if (profesion == null) return NotFound();

            var model = new ProfesionViewModel { Id = profesion.Id, Nom = profesion.Nom, Des = profesion.Des };
            return View(model);
        }

        // POST: Profesions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProfesionViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var profesion = new Profesion { Id = model.Id, Nom = model.Nom, Des = model.Des };
                await _profesionRepository.UpdateProfesionAsync(profesion);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Profesions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var profesion = await _profesionRepository.GetProfesionByIdAsync(id.Value);
            if (profesion == null) return NotFound();

            return View(profesion);
        }

        // POST: Profesions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _profesionRepository.DeleteProfesionAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionExists(int id)
        {
            return _profesionRepository.ProfesionExists(id);
        }
    }
}

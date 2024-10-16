using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using personapi_dotnet.Models.Repositories;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.ViewModels;

namespace personapi_dotnet.Controllers
{
    public class TelefonoesController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepository;
        private readonly IPersonaRepository _personaRepository;

        public TelefonoesController(ITelefonoRepository telefonoRepository, IPersonaRepository personaRepository)
        {
            _telefonoRepository = telefonoRepository;
            _personaRepository = personaRepository;
        }

        // GET: Telefonoes
        public async Task<IActionResult> Index()
        {
            return View(await _telefonoRepository.GetAllTelefonosAsync());
        }

        // GET: Telefonoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var telefono = await _telefonoRepository.GetTelefonoByIdAsync(id);
            if (telefono == null) return NotFound();
            return View(telefono);
        }

        // GET: Telefonoes/Create
        public IActionResult Create()
        {
            var personas = _personaRepository.GetAllAsync().Result;
            ViewData["Duenio"] = new SelectList(personas.Select(p => new
            {
                Cc = p.Cc,
                NombreCompleto = $"{p.Cc} - {p.Nombre} {p.Apellido}"
            }), "Cc", "NombreCompleto");
            return View();
        }

        // POST: Telefonoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TelefonoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var telefono = new Telefono { Num = model.Num, Oper = model.Oper, Duenio = model.Duenio };
                await _telefonoRepository.AddTelefonoAsync(telefono);
                return RedirectToAction(nameof(Index));
            }

            // Re-populate personas if the model state is invalid
            var personas = _personaRepository.GetAllAsync().Result;
            ViewData["Duenio"] = new SelectList(personas.Select(p => new
            {
                Cc = p.Cc,
                NombreCompleto = $"{p.Cc} - {p.Nombre} {p.Apellido}"
            }), "Cc", "NombreCompleto", model.Duenio);
            return View(model);
        }

        // GET: Telefonoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var telefono = await _telefonoRepository.GetTelefonoByIdAsync(id);
            if (telefono == null) return NotFound();

            var model = new TelefonoViewModel { Num = telefono.Num, Oper = telefono.Oper, Duenio = telefono.Duenio };
            var personas = await _personaRepository.GetAllAsync();
            ViewData["Duenio"] = new SelectList(personas.Select(p => new
            {
                Cc = p.Cc,
                NombreCompleto = $"{p.Cc} - {p.Nombre} {p.Apellido}"
            }), "Cc", "NombreCompleto", model.Duenio);
            return View(model);
        }

        // POST: Telefonoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, TelefonoViewModel model)
        {
            if (id != model.Num) return NotFound();

            if (ModelState.IsValid)
            {
                var telefono = new Telefono { Num = model.Num, Oper = model.Oper, Duenio = model.Duenio };
                await _telefonoRepository.UpdateTelefonoAsync(telefono);
                return RedirectToAction(nameof(Index));
            }

            var personas = await _personaRepository.GetAllAsync();
            ViewData["Duenio"] = new SelectList(personas.Select(p => new
            {
                Cc = p.Cc,
                NombreCompleto = $"{p.Cc} - {p.Nombre} {p.Apellido}"
            }), "Cc", "NombreCompleto", model.Duenio);
            return View(model);
        }

        // GET: Telefonoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var telefono = await _telefonoRepository.GetTelefonoByIdAsync(id);
            if (telefono == null) return NotFound();

            return View(telefono);
        }

        // POST: Telefonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _telefonoRepository.DeleteTelefonoAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(string id)
        {
            return _telefonoRepository.TelefonoExists(id);
        }
    }
}

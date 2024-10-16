using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.ViewModels;
using personapi_dotnet.Models.Repositories;
using personapi_dotnet.Models.Repositories.Implementations;

namespace personapi_dotnet.Controllers
{
    public class PersonasController : Controller
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly ITelefonoRepository _telefonoRepository;
        private readonly IEstudioRepository _estudioRepository;

        public PersonasController(IPersonaRepository personaRepository, ITelefonoRepository telefonoRepository, IEstudioRepository estudioRepository)
        {
            _personaRepository = personaRepository;
            _telefonoRepository = telefonoRepository;
            _estudioRepository = estudioRepository;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var personas = await _personaRepository.GetAllAsync();
            return View(personas);
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var persona = await _personaRepository.GetByIdAsync(id.Value);
            if (persona == null) return NotFound();

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var persona = new Persona
                {
                    Cc = model.Cc,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Genero = model.Genero,
                    Edad = model.Edad
                };

                await _personaRepository.AddAsync(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var persona = await _personaRepository.GetByIdAsync(id.Value);
            if (persona == null) return NotFound();

            var model = new PersonaViewModel
            {
                Cc = persona.Cc,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Genero = persona.Genero,
                Edad = persona.Edad
            };

            return View(model);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PersonaViewModel model)
        {
            if (id != model.Cc) return NotFound();

            if (ModelState.IsValid)
            {
                var persona = await _personaRepository.GetByIdAsync(id);
                if (persona == null) return NotFound();

                persona.Nombre = model.Nombre;
                persona.Apellido = model.Apellido;
                persona.Genero = model.Genero;
                persona.Edad = model.Edad;

                await _personaRepository.UpdateAsync(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var persona = await _personaRepository.GetByIdAsync(id.Value);
            if (persona == null) return NotFound();

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            bool tieneEstudios = await _estudioRepository.PersonaTieneEstudiosAsync(id);
            bool tieneTelefonos = await _telefonoRepository.PersonaTieneTelefonosAsync(id);

            if (tieneEstudios || tieneTelefonos)
            {
                ModelState.AddModelError("", "No se puede eliminar la persona porque tiene estudios o teléfonos asociados.");
                return View(persona);
            }

            await _personaRepository.DeleteAsync(persona);

            return RedirectToAction(nameof(Index));
        }

    }
}

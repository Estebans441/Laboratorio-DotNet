// Controllers/EstudiosController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repositories;
using personapi_dotnet.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    public class EstudiosController : Controller
    {
        private readonly IEstudioRepository _estudioRepository;
        private readonly IProfesionRepository _profesionRepository;
        private readonly IPersonaRepository _personaRepository;

        public EstudiosController(IEstudioRepository estudioRepository, IProfesionRepository profesionRepository, IPersonaRepository personaRepository)
        {
            _estudioRepository = estudioRepository;
            _profesionRepository = profesionRepository;
            _personaRepository = personaRepository;
        }

        // GET: Estudios
        public async Task<IActionResult> Index()
        {
            return View(await _estudioRepository.GetAllEstudiosAsync());
        }

        // GET: Estudios/Details
        public async Task<IActionResult> Details(int? ccPer, int? idProf)
        {
            if (ccPer == null || idProf == null)
            {
                return NotFound();
            }

            var estudio = await _estudioRepository.GetEstudioByIdAsync(ccPer.Value, idProf.Value);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // GET: Estudios/Create
        // GET: Estudios/Create
        public async Task<IActionResult> Create()
        {
            // Obtener las personas del repositorio y crear una lista que incluya ID y nombre completo
            var personas = await _personaRepository.GetAllAsync();
            var personasSelectList = personas.Select(p => new
            {
                Cc = p.Cc,
                NombreCompleto = $"{p.Cc} - {p.Nombre} {p.Apellido}"
            });

            // Obtener las profesiones del repositorio y crear una lista que incluya ID y nombre
            var profesiones = await _profesionRepository.GetAllProfesionsAsync();
            var profesionesSelectList = profesiones.Select(p => new
            {
                Id = p.Id,
                NombreProfesion = $"{p.Id} - {p.Nom}"
            });

            // Asignar las listas al ViewData
            ViewData["CcPer"] = new SelectList(personasSelectList, "Cc", "NombreCompleto");
            ViewData["IdProf"] = new SelectList(profesionesSelectList, "Id", "NombreProfesion");
            return View();
        }

        // POST: Estudios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstudioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var estudio = new Estudio
                {
                    CcPer = model.CcPer,
                    IdProf = model.IdProf,
                    Fecha = model.Fecha,
                    Univer = model.Univer
                };

                await _estudioRepository.AddEstudioAsync(estudio);
                return RedirectToAction(nameof(Index));
            }

            // Si el modelo no es válido, recargamos las listas de personas y profesiones
            var personas = await _personaRepository.GetAllAsync();
            var personasSelectList = personas.Select(p => new
            {
                Cc = p.Cc,
                NombreCompleto = $"{p.Cc} - {p.Nombre} {p.Apellido}"
            });

            var profesiones = await _profesionRepository.GetAllProfesionsAsync();
            var profesionesSelectList = profesiones.Select(p => new
            {
                Id = p.Id,
                NombreProfesion = $"{p.Id} - {p.Nom}"
            });

            ViewData["CcPer"] = new SelectList(personasSelectList, "Cc", "NombreCompleto", model.CcPer);
            ViewData["IdProf"] = new SelectList(profesionesSelectList, "Id", "NombreProfesion", model.IdProf);
            return View(model);
        }

        // GET: Estudios/Edit
        public async Task<IActionResult> Edit(int? ccPer, int? idProf)
        {
            if (ccPer == null || idProf == null)
            {
                return NotFound();
            }

            var estudio = await _estudioRepository.GetEstudioByIdAsync(ccPer.Value, idProf.Value);
            if (estudio == null)
            {
                return NotFound();
            }

            var model = new EstudioViewModel
            {
                CcPer = estudio.CcPer,
                IdProf = estudio.IdProf,
                Fecha = estudio.Fecha,
                Univer = estudio.Univer
            };

            // Recargamos las listas de personas y profesiones
            var personas = await _personaRepository.GetAllAsync();
            var personasSelectList = personas.Select(p => new
            {
                Cc = p.Cc,
                NombreCompleto = $"{p.Cc} - {p.Nombre} {p.Apellido}"
            });

            var profesiones = await _profesionRepository.GetAllProfesionsAsync();
            var profesionesSelectList = profesiones.Select(p => new
            {
                Id = p.Id,
                NombreProfesion = $"{p.Id} - {p.Nom}"
            });

            ViewData["CcPer"] = new SelectList(personasSelectList, "Cc", "NombreCompleto", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(profesionesSelectList, "Id", "NombreProfesion", estudio.IdProf);
            return View(model);
        }

        // POST: Estudios/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ccPer, int idProf, EstudioViewModel model)
        {
            if (ccPer != model.CcPer || idProf != model.IdProf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var estudio = await _estudioRepository.GetEstudioByIdAsync(ccPer, idProf);
                if (estudio == null)
                {
                    return NotFound();
                }

                estudio.Fecha = model.Fecha;
                estudio.Univer = model.Univer;

                await _estudioRepository.UpdateEstudioAsync(estudio);
                return RedirectToAction(nameof(Index));
            }

            // Si el modelo no es válido, recargamos las listas de personas y profesiones
            var personas = await _personaRepository.GetAllAsync();
            var personasSelectList = personas.Select(p => new
            {
                Cc = p.Cc,
                NombreCompleto = $"{p.Cc} - {p.Nombre} {p.Apellido}"
            });

            var profesiones = await _profesionRepository.GetAllProfesionsAsync();
            var profesionesSelectList = profesiones.Select(p => new
            {
                Id = p.Id,
                NombreProfesion = $"{p.Id} - {p.Nom}"
            });

            ViewData["CcPer"] = new SelectList(personasSelectList, "Cc", "NombreCompleto", model.CcPer);
            ViewData["IdProf"] = new SelectList(profesionesSelectList, "Id", "NombreProfesion", model.IdProf);
            return View(model);
        }


        // GET: Estudios/Delete
        public async Task<IActionResult> Delete(int? ccPer, int? idProf)
        {
            if (ccPer == null || idProf == null)
            {
                return NotFound();
            }

            var estudio = await _estudioRepository.GetEstudioByIdAsync(ccPer.Value, idProf.Value);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // POST: Estudios/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ccPer, int idProf)
        {
            await _estudioRepository.DeleteEstudioAsync(ccPer, idProf);
            return RedirectToAction(nameof(Index));
        }

        private bool EstudioExists(int ccPer, int idProf)
        {
            return _estudioRepository.EstudioExists(ccPer, idProf);
        }
    }
}

// Repositories/ProfesionRepository.cs
using personapi_dotnet.Context;
using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.Repositories.Implementations
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly DBContext _context;

        public ProfesionRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesion>> GetAllProfesionsAsync()
        {
            return await _context.Profesions.ToListAsync();
        }

        public async Task<Profesion> GetProfesionByIdAsync(int id)
        {
            return await _context.Profesions.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProfesionAsync(Profesion profesion)
        {
            await _context.Profesions.AddAsync(profesion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfesionAsync(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesionAsync(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
                await _context.SaveChangesAsync();
            }
        }

        public bool ProfesionExists(int id)
        {
            return _context.Profesions.Any(e => e.Id == id);
        }
    }
}

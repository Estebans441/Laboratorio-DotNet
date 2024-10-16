using personapi_dotnet.Context;
using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Repositories.Implementations
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly DBContext _context;

        public PersonaRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas.FirstOrDefaultAsync(m => m.Cc == id);
        }

        public async Task AddAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Persona persona)
        {
            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Persona persona)
        {
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }

        public bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Cc == id);
        }
    }
}

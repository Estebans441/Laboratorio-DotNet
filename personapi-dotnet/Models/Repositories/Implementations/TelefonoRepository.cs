using personapi_dotnet.Context;
using personapi_dotnet.Models.Repositories;
using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.Repositories.Implementations
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly DBContext _context;

        public TelefonoRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefono>> GetAllTelefonosAsync()
        {
            return await _context.Telefonos.Include(t => t.DuenioNavigation).ToListAsync();
        }

        public async Task<Telefono> GetTelefonoByIdAsync(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            System.Linq.Expressions.Expression<Func<Telefono, Persona>> navigationPropertyPath = t => t.DuenioNavigation;
            return await _context.Telefonos.Include(navigationPropertyPath)
                                           .FirstOrDefaultAsync(t => t.Num == id);
        }

        public async Task AddTelefonoAsync(Telefono telefono)
        {
            await _context.Telefonos.AddAsync(telefono);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTelefonoAsync(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTelefonoAsync(string id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                await _context.SaveChangesAsync();
            }
        }

        public bool TelefonoExists(string id)
        {
            return _context.Telefonos.Any(e => e.Num == id);
        }

        public async Task<bool> PersonaTieneTelefonosAsync(int duenio)
        {
            return await _context.Telefonos.AnyAsync(t => t.Duenio == duenio);
        }
    }
}
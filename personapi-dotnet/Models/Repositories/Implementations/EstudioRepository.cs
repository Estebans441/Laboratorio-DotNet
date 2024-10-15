// Repositories/EstudioRepository.cs
using personapi_dotnet.Context;
using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using personapi_dotnet.Models.Repositories;

namespace personapi_dotnet.Models.Repositories.Implementations
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly DBContext _context;

        public EstudioRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudio>> GetAllEstudiosAsync()
        {
            return await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .ToListAsync();
        }

        public async Task<Estudio> GetEstudioByIdAsync(int ccPer, int idProf)
        {
            return await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(e => e.CcPer == ccPer && e.IdProf == idProf);
        }

        public async Task AddEstudioAsync(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstudioAsync(Estudio estudio)
        {
            _context.Estudios.Update(estudio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstudioAsync(int ccPer, int idProf)
        {
            var estudio = await GetEstudioByIdAsync(ccPer, idProf);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                await _context.SaveChangesAsync();
            }
        }

        public bool EstudioExists(int ccPer, int idProf)
        {
            return _context.Estudios.Any(e => e.CcPer == ccPer && e.IdProf == idProf);
        }
    }
}

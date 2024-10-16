// Interfaces/IEstudioRepository.cs
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Models.Repositories
{
    public interface IEstudioRepository
    {
        Task<IEnumerable<Estudio>> GetAllEstudiosAsync();
        Task<Estudio> GetEstudioByIdAsync(int ccPer, int idProf);
        Task AddEstudioAsync(Estudio estudio);
        Task UpdateEstudioAsync(Estudio estudio);
        Task DeleteEstudioAsync(int ccPer, int idProf);
        bool EstudioExists(int ccPer, int idProf);
        Task<bool> PersonaTieneEstudiosAsync(int ccPer);
        Task<bool> ProfesionTieneEstudiosAsync(int idProf);
    }
}

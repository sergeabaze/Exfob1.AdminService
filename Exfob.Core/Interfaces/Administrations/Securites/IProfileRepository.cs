using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Core.Interfaces.Administrations.Securites
{
    public  interface IProfileRepository : IGenericRepository<Profil>
    {
        Task<IEnumerable<Profil>> GetListe();
        Task<Profil> GetById(int Id);
        Task<int> Creation(Profil entity);
        Task Update(Profil entity);
        Task Delete(int id);
    }
}

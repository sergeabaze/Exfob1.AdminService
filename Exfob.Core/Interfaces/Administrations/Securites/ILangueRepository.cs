using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Core.Interfaces.Administrations.Securites
{
    public  interface ILangueRepository : IGenericRepository<Langue>
    {
        Task<IEnumerable<Langue>> GetListe();
        Task<Langue> GetById(int Id);
        Task<int> Creation(Langue entity);
        Task Update(Langue entity);
        Task Delete(int id);
    }
}

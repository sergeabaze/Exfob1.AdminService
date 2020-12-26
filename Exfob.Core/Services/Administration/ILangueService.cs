using Exfob.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Core.Services.Administration
{
    public  interface ILangueService
    {
        Task<IEnumerable<Langue>> ObtenireLangueListe();
        Task<Langue> ObtenireLangueParId(int Id);
        Task<int> CreationLangue(Langue entity);
        Task MisejourLangue(Langue entity);
        Task SuppressionLangue(int id);

       
    }
}

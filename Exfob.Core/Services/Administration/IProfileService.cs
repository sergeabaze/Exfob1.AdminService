using Exfob.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Core.Services.Administration
{
    public  interface IProfileService
    {
        Task<IEnumerable<Profil>> ObtenireProfileListe();
        Task<Profil> ObtenireProfileParId(int Id);
        Task<int> CreationProfile(Profil entity);
        Task MisejourProfile(Profil entity);
        Task SuppressionProfile(int id);

       
    }
}

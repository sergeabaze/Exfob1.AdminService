using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
using Exfob.Models.CustomModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exfob.Core.Interfaces.Administrations
{
    public interface ILookUpRepository: IGenericDapperRepository<LookUpModel>
    {
        Task<IEnumerable<Acconier>> GetAconierListe(int SiteOperationID);
        Task<IEnumerable<SocieteForListe>> GetSocieteListe(int SiegeID = 0);

        Task<IEnumerable<Profil>> GetProfileListe();
        Task<IEnumerable<Langue>> GetLangueListe();
        Task<IEnumerable<SiteOperationForListe>> GetSiteOperationListe();
        Task<IEnumerable<TypeMateriel>> GetTypeMaterielListe();
        Task<IEnumerable<SouTraitanceForListe>> GetSousTraitanceListe(int SiteOperationID);
        Task<IEnumerable<DroitsForListe>> GetDroitListe(int ProfileID);
        Task<IEnumerable<SiteAutoriseForListe>> GetSiteAutoriseListe(int UtilisateurID);
        Task<IEnumerable<EssenceForListe>> GetEssenceListe(int SocieteID);
        Task<IEnumerable<OperateurForListe>> GetOperateurListe(int SiteOperationID);
        Task<IEnumerable<ChantierForListe>> GetChantierListe(int SiteOperationID);
    }
}

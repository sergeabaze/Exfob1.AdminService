using AutoMapper;
using Exfob.Models.Administration;
using Exfob.Models.CustomModels;
using Exfob1.Models.Adminstrations.Utilisateurs.Request;
using Exfob1.Models.Adminstrations.Utilisateurs.Response;

namespace Exfob1.Controllers.Administration.Securite.Utilisateurs.Mappeur
{
    public class UtilisateurMappeur : Profile
    {
        public UtilisateurMappeur()
        {
#pragma warning disable 1591
            CreateMap<Utilisateur, UtilisateurList>();
            CreateMap<Utilisateur, UtilisateurReponse>();
            CreateMap<UtilisateurEdit, Utilisateur>();
            CreateMap<UtilisateurRequestCreate, Utilisateur>();
            CreateMap<Profil, ProfileforListeVm>();
            CreateMap<Langue, LangueForListeVm>();
            CreateMap<SiteOperationForListe, SiteOperationForListVm>();
            CreateMap<UtilisateurEdit, UtilisateurForEditReponse>();
            CreateMap<LangueLoginModel, LangueLoginReponse>();
            CreateMap<ProfileLoginModel, ProfileLoginReponse>();
            CreateMap<DroitsLoginModel, DroitsLoginReponse>();
            CreateMap<ModuleLoginModel, ModuleLoginReponse>();
            CreateMap<SiteOperationLoginModel, SiteOperationLoginReponse>();
            CreateMap<SiegeLoginModel, SiegeLoginReponse>();
            CreateMap<SocieteLoginModel, SocieteLoginReponse>();
            CreateMap<SiteOperationsAuthorizerLoginModel, SiteOperationsAuthorizerLoginReponse>();
            CreateMap<ProfileAuthorizerLoginModel, ProfileAuthorizerLoginReponse>();
            CreateMap<DroitsAuthorizerLoginModel, DroitsAuthorizerLoginReponse>();
            CreateMap<UtilisateurLoginModel, UtilisateurLoginReponse>();
#pragma warning restore 1591
        }
    }
}

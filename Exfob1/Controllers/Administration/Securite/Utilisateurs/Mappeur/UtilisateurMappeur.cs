using AutoMapper;
using Exfob.Models.Administration;
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
            CreateMap<UtilisateurCreate, Utilisateur>();
#pragma warning restore 1591
        }
    }
}

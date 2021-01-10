using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;

namespace Exfob1.Controllers.Administration.Securite.ProfilesMappeur
{
    public class ProfileMappeur : Profile
    {
        public ProfileMappeur()
        {
#pragma warning disable 1591
            CreateMap<Profil, ProfileListe>();
            CreateMap<Profil, ProfileResponse>();
            CreateMap<ProfileEdit, Profil>();
            CreateMap<ProfileRequest, Profil>();
#pragma warning restore 1591
        }
    }
}

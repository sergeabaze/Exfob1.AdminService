using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;

namespace Exfob1.Controllers.Administration.Securite.Langues.Mappeur
{
    public class LangueMappeur : Profile
    {
        public LangueMappeur()
        {
#pragma warning disable 1591
            CreateMap<Langue, LangueListe>();
            CreateMap<Langue, LangueReponse>();
            CreateMap<LangueEdit, Langue>();
            CreateMap<LangueRequest, Langue>();

#pragma warning restore 1591
        }
    }
}

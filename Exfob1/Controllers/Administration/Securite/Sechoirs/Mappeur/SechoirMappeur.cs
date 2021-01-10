using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SechoirMappeur : Profile
	{
		public SechoirMappeur()
		{
			CreateMap<Sechoir, SechoirListe>();
			CreateMap<Sechoir, SechoirReponse>();
			CreateMap<SechoirEdit, Sechoir>();
			CreateMap<SechoirRequest, Sechoir>();
		}
	}
}

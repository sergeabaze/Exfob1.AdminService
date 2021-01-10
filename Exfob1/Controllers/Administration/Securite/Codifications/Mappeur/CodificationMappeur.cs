using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class CodificationMappeur : Profile
	{
		public CodificationMappeur()
		{
			CreateMap<Codification, CodificationListe>();
			CreateMap<Codification, CodificationReponse>();
			CreateMap<CodificationEdit, Codification>();
			CreateMap<CodificationRequest, Codification>();
		}
	}
}

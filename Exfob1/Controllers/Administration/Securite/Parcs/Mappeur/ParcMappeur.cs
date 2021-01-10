using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ParcMappeur : Profile
	{
		public ParcMappeur()
		{
			CreateMap<Parc, ParcListe>();
			CreateMap<Parc, ParcReponse>();
			CreateMap<ParcEdit, Parc>();
			CreateMap<ParcRequest, Parc>();
		}
	}
}

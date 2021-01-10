using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ComptabiliteMappeur : Profile
	{
		public ComptabiliteMappeur()
		{
			CreateMap<Comptabilite, ComptabiliteListe>();
			CreateMap<Comptabilite, ComptabiliteReponse>();
			CreateMap<ComptabiliteEdit, Comptabilite>();
			CreateMap<ComptabiliteRequest, Comptabilite>();
		}
	}
}

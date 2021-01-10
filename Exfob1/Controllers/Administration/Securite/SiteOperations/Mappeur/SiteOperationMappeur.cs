using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SiteOperationMappeur : Profile
	{
		public SiteOperationMappeur()
		{
			CreateMap<SiteOperation, SiteOperationListe>();
			CreateMap<SiteOperation, SiteOperationReponse>();
			CreateMap<SiteOperationEdit, SiteOperation>();
			CreateMap<SiteOperationRequest, SiteOperation>();
		}
	}
}

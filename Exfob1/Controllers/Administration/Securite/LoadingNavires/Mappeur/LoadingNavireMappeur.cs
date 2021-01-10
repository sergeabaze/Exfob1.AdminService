using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class LoadingNavireMappeur : Profile
	{
		public LoadingNavireMappeur()
		{
			CreateMap<LoadingNavire, LoadingNavireListe>();
			CreateMap<LoadingNavire, LoadingNavireReponse>();
			CreateMap<LoadingNavireEdit, LoadingNavire>();
			CreateMap<LoadingNavireRequest, LoadingNavire>();
		}
	}
}

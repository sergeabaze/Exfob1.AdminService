using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class CompteTiersMappeur : Profile
	{
		public CompteTiersMappeur()
		{
			CreateMap<CompteTier, CompteTiersListe>();
			CreateMap<CompteTier, CompteTiersReponse>();
			CreateMap<CompteTiersEdit, CompteTier>();
			CreateMap<CompteTiersRequest, CompteTier>();
		}
	}
}

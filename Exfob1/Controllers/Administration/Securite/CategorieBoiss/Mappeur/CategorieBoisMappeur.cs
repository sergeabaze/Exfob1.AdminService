using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class CategorieBoisMappeur : Profile
	{
		public CategorieBoisMappeur()
		{
			CreateMap<CategorieBois, CategorieBoisListe>();
			CreateMap<CategorieBois, CategorieBoisReponse>();
			CreateMap<CategorieBoisEdit, CategorieBois>();
			CreateMap<CategorieBoisRequest, CategorieBois>();
		}
	}
}

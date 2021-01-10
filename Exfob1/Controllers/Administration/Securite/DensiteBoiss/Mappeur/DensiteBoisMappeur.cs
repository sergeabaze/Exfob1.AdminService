using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class DensiteBoisMappeur : Profile
	{
		public DensiteBoisMappeur()
		{
			CreateMap<DensiteBois, DensiteBoisListe>();
			CreateMap<DensiteBois, DensiteBoisReponse>();
			CreateMap<DensiteBoisEdit, DensiteBois>();
			CreateMap<DensiteBoisRequest, DensiteBois>();
		}
	}
}

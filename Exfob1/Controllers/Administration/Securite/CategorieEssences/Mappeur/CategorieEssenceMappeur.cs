using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class CategorieEssenceMappeur : Profile
	{
		public CategorieEssenceMappeur()
		{
			CreateMap<CategorieEssence, CategorieEssenceListe>();
			CreateMap<CategorieEssence, CategorieEssenceReponse>();
			CreateMap<CategorieEssenceEdit, CategorieEssence>();
			CreateMap<CategorieEssenceRequest, CategorieEssence>();
		}
	}
}

using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ClasseEssenceMappeur : Profile
	{
		public ClasseEssenceMappeur()
		{
			CreateMap<ClasseEssence, ClasseEssenceListe>();
			CreateMap<ClasseEssence, ClasseEssenceReponse>();
			CreateMap<ClasseEssenceEdit, ClasseEssence>();
			CreateMap<ClasseEssenceRequest, ClasseEssence>();
		}
	}
}

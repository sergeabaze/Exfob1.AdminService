using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TypeoperationControleMappeur : Profile
	{
		public TypeoperationControleMappeur()
		{
			CreateMap<TypeoperationControle, TypeoperationControleListe>();
			CreateMap<TypeoperationControle, TypeoperationControleReponse>();
			CreateMap<TypeoperationControleEdit, TypeoperationControle>();
			CreateMap<TypeoperationControleRequest, TypeoperationControle>();
		}
	}
}

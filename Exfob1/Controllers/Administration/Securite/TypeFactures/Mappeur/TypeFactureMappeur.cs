using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TypeFactureMappeur : Profile
	{
		public TypeFactureMappeur()
		{
			CreateMap<TypeFacture, TypeFactureListe>();
			CreateMap<TypeFacture, TypeFactureReponse>();
			CreateMap<TypeFactureEdit, TypeFacture>();
			CreateMap<TypeFactureRequest, TypeFacture>();
		}
	}
}

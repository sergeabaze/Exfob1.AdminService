using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TypeClientMappeur : Profile
	{
		public TypeClientMappeur()
		{
			CreateMap<TypeClient, TypeClientListe>();
			CreateMap<TypeClient, TypeClientReponse>();
			CreateMap<TypeClientEdit, TypeClient>();
			CreateMap<TypeClientRequest, TypeClient>();
		}
	}
}

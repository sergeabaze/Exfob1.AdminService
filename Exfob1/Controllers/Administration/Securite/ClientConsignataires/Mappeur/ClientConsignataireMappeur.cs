using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ClientConsignataireMappeur : Profile
	{
		public ClientConsignataireMappeur()
		{
			CreateMap<ClientConsignataire, ClientConsignataireListe>();
			CreateMap<ClientConsignataire, ClientConsignataireReponse>();
			CreateMap<ClientConsignataireEdit, ClientConsignataire>();
			CreateMap<ClientConsignataireRequest, ClientConsignataire>();
		}
	}
}

using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ClientAdresseMappeur : Profile
	{
		public ClientAdresseMappeur()
		{
			CreateMap<ClientAdresse, ClientAdresseListe>();
			CreateMap<ClientAdresse, ClientAdresseReponse>();
			CreateMap<ClientAdresseEdit, ClientAdresse>();
			CreateMap<ClientAdresseRequest, ClientAdresse>();
		}
	}
}

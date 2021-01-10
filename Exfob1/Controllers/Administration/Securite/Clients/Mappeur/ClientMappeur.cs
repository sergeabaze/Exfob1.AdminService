using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ClientMappeur : Profile
	{
		public ClientMappeur()
		{
			CreateMap<Client, ClientListe>();
			CreateMap<Client, ClientReponse>();
			CreateMap<ClientEdit, Client>();
			CreateMap<ClientRequest, Client>();
		}
	}
}

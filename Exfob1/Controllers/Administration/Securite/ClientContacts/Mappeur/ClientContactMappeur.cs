using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ClientContactMappeur : Profile
	{
		public ClientContactMappeur()
		{
			CreateMap<ClientContact, ClientContactListe>();
			CreateMap<ClientContact, ClientContactReponse>();
			CreateMap<ClientContactEdit, ClientContact>();
			CreateMap<ClientContactRequest, ClientContact>();
		}
	}
}

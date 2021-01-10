using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ListeServiceVenteMappeur : Profile
	{
		public ListeServiceVenteMappeur()
		{
			CreateMap<ListeServiceVente, ListeServiceVenteListe>();
			CreateMap<ListeServiceVente, ListeServiceVenteReponse>();
			CreateMap<ListeServiceVenteEdit, ListeServiceVente>();
			CreateMap<ListeServiceVenteRequest, ListeServiceVente>();
		}
	}
}

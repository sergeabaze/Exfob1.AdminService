using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ServiceVenteMappeur : Profile
	{
		public ServiceVenteMappeur()
		{
			CreateMap<ServiceVente, ServiceVenteListe>();
			CreateMap<ServiceVente, ServiceVenteReponse>();
			CreateMap<ServiceVenteEdit, ServiceVente>();
			CreateMap<ServiceVenteRequest, ServiceVente>();
		}
	}
}

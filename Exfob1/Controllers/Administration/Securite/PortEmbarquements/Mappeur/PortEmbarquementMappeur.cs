using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class PortEmbarquementMappeur : Profile
	{
		public PortEmbarquementMappeur()
		{
			CreateMap<PortEmbarquement, PortEmbarquementListe>();
			CreateMap<PortEmbarquement, PortEmbarquementReponse>();
			CreateMap<PortEmbarquementEdit, PortEmbarquement>();
			CreateMap<PortEmbarquementRequest, PortEmbarquement>();
		}
	}
}

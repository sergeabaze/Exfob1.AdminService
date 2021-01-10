using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class StatutOperationMappeur : Profile
	{
		public StatutOperationMappeur()
		{
			CreateMap<StatutOperation, StatutOperationListe>();
			CreateMap<StatutOperation, StatutOperationReponse>();
			CreateMap<StatutOperationEdit, StatutOperation>();
			CreateMap<StatutOperationRequest, StatutOperation>();
		}
	}
}

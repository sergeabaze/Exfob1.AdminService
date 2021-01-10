using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class FamilleMappeur : Profile
	{
		public FamilleMappeur()
		{
			CreateMap<Famille, FamilleListe>();
			CreateMap<Famille, FamilleReponse>();
			CreateMap<FamilleEdit, Famille>();
			CreateMap<FamilleRequest, Famille>();
		}
	}
}

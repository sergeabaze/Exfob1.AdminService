using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class GroupeMappeur : Profile
	{
		public GroupeMappeur()
		{
			CreateMap<Groupe, GroupeListe>();
			CreateMap<Groupe, GroupeReponse>();
			CreateMap<GroupeEdit, Groupe>();
			CreateMap<GroupeRequest, Groupe>();
		}
	}
}

using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using System.Threading.Tasks;
namespace Exfob1.Controllers.Administration
{
	public interface IPortEmbarquementBLL
	{
		Task<WebApiListResponse<PortEmbarquementListe>> ObtenirePortEmbarquementListe();
		Task<WebApiSingleResponse<PortEmbarquementReponse>> ObtenirePortEmbarquementParId(int Id);
		Task<WebApiSingleResponse<PortEmbarquementReponse>> CreationPortEmbarquement(PortEmbarquementRequest entity);
		Task<WebApiSingleResponse<PortEmbarquementReponse>> MisejourPortEmbarquement(PortEmbarquementEdit entity);
		Task<WebApiSingleResponse<PortEmbarquementReponse>> SuppressionPortEmbarquement(int id);
	}
}

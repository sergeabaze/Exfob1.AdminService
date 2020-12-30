using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface INatureConteneurRepository : IGenericRepository<NatureConteneur>
	{
		Task<IEnumerable<NatureConteneur>> GetListe();
		Task<NatureConteneur> GetById(int Id);
		Task<int> Creation(NatureConteneur entity);
		Task Update(NatureConteneur entity);
		Task Delete(int id);
	}
}

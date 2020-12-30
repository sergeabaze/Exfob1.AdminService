using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITypeEquipeRepository : IGenericRepository<TypeEquipe>
	{
		Task<IEnumerable<TypeEquipe>> GetListe();
		Task<TypeEquipe> GetById(int Id);
		Task<int> Creation(TypeEquipe entity);
		Task Update(TypeEquipe entity);
		Task Delete(int id);
	}
}

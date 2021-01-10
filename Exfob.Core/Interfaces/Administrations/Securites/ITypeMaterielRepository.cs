using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface ITypeMaterielRepository : IGenericRepository<TypeMateriel>
	{
		Task<IEnumerable<TypeMateriel>> GetListe();
		Task<TypeMateriel> GetById(int Id);
		Task<int> Creation(TypeMateriel entity);
		Task Update(TypeMateriel entity);
		Task Delete(int id);
	}
}

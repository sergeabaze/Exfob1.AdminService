using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IQualiteBoisRepository : IGenericRepository<QualiteBois>
	{
		Task<IEnumerable<QualiteBois>> GetListe();
		Task<QualiteBois> GetById(int Id);
		Task<int> Creation(QualiteBois entity);
		Task Update(QualiteBois entity);
		Task Delete(int id);
	}
}

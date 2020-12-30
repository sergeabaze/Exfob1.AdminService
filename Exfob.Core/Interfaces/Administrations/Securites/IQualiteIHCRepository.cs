using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
    public  interface IQualiteIHCRepository : IGenericRepository<QualiteIHC>
	{
		Task<IEnumerable<QualiteIHC>> GetListe();
		Task<QualiteIHC> GetById(int Id);
		Task<int> Creation(QualiteIHC entity);
		Task Update(QualiteIHC entity);
		Task Delete(int id);
	}
}

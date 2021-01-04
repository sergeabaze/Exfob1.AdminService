using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface ICategorieEssenceRepository : IGenericRepository<CategorieEssence>
	{
		Task<IEnumerable<CategorieEssence>> GetListe();
		Task<CategorieEssence> GetById(int Id);
		Task<int> Creation(CategorieEssence entity);
		Task Update(CategorieEssence entity);
		Task Delete(int id);
	}
}

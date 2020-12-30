using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface IClasseEssenceRepository : IGenericRepository<ClasseEssence>
	{
		Task<IEnumerable<ClasseEssence>> GetListe();
		Task<ClasseEssence> GetById(int Id);
		Task<int> Creation(ClasseEssence entity);
		Task Update(ClasseEssence entity);
		Task Delete(int id);
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface IComptabiliteRepository : IGenericRepository<Comptabilite>
	{
		Task<IEnumerable<Comptabilite>> GetListe();
		Task<Comptabilite> GetById(int Id);
		Task<int> Creation(Comptabilite entity);
		Task Update(Comptabilite entity);
		Task Delete(int id);
	}
}

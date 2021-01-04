using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface ICompteProduitRepository : IGenericRepository<CompteProduit>
	{
		Task<IEnumerable<CompteProduit>> GetListe();
		Task<CompteProduit> GetById(int Id);
		Task<int> Creation(CompteProduit entity);
		Task Update(CompteProduit entity);
		Task Delete(int id);
	}
}

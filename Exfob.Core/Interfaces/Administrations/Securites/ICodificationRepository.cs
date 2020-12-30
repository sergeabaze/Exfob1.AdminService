using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface ICodificationRepository : IGenericRepository<Codification>
	{
		Task<IEnumerable<Codification>> GetListe();
		Task<Codification> GetById(int Id);
		Task<int> Creation(Codification entity);
		Task Update(Codification entity);
		Task Delete(int id);
	}
}

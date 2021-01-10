using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface IClientRepository : IGenericRepository<Client>
	{
		Task<IEnumerable<Client>> GetListe();
		Task<Client> GetById(int Id);
		Task<int> Creation(Client entity);
		Task Update(Client entity);
		Task Delete(int id);
	}
}

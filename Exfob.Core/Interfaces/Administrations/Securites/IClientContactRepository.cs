using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface IClientContactRepository : IGenericRepository<ClientContact>
	{
		Task<IEnumerable<ClientContact>> GetListe();
		Task<ClientContact> GetById(int Id);
		Task<int> Creation(ClientContact entity);
		Task Update(ClientContact entity);
		Task Delete(int id);
	}
}

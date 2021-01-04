using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface IClientAdresseRepository : IGenericRepository<ClientAdresse>
	{
		Task<IEnumerable<ClientAdresse>> GetListe();
		Task<ClientAdresse> GetById(int Id);
		Task<int> Creation(ClientAdresse entity);
		Task Update(ClientAdresse entity);
		Task Delete(int id);
	}
}

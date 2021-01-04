using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface IClientConsignataireRepository : IGenericRepository<ClientConsignataire>
	{
		Task<IEnumerable<ClientConsignataire>> GetListe();
		Task<ClientConsignataire> GetById(int Id);
		Task<int> Creation(ClientConsignataire entity);
		Task Update(ClientConsignataire entity);
		Task Delete(int id);
	}
}

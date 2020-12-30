using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Exfob.Models.Administration;
namespace Exfob.Core.Interfaces.Repository
{
	public  interface ICodePlaquetteRepository : IGenericRepository<CodePlaquette>
	{
		Task<IEnumerable<CodePlaquette>> GetListe();
		Task<CodePlaquette> GetById(int Id);
		Task<int> Creation(CodePlaquette entity);
		Task Update(CodePlaquette entity);
		Task Delete(int id);
	}
}

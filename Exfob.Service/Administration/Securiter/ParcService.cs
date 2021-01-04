using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ParcService : IParcService
	{

		private readonly IParcRepository _repository;

		public ParcService(IParcRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Parc>> ObtenireParcListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Parc> ObtenireParcParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationParc(Parc entity)
		{
			await _repository.Creation(entity);
			return entity.ParcID;
		}

		public async  Task MisejourParc(Parc entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionParc(int id)
		{
			await _repository.Delete(id);
		}
	}
}

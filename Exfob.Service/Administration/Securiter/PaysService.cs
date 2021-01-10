using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class PaysService : IPaysService
	{

		private readonly IPaysRepository _repository;

		public PaysService(IPaysRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Pays>> ObtenirePaysListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Pays> ObtenirePaysParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationPays(Pays entity)
		{
			await _repository.Creation(entity);
			return entity.PaysID;
		}

		public async  Task MisejourPays(Pays entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionPays(int id)
		{
			await _repository.Delete(id);
		}
	}
}

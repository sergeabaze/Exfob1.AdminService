using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class CompteTiersService : ICompteTiersService
	{

		private readonly ICompteTiersRepository _repository;

		public CompteTiersService(ICompteTiersRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<CompteTier>> ObtenireCompteTierListe()
		{
			return await _repository.GetListe();
		}

		public async Task<CompteTier> ObtenireCompteTierParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationCompteTier(CompteTier entity)
		{
			await _repository.Creation(entity);
			return entity.CompteTiersID;
		}

		public async  Task MisejourCompteTier(CompteTier entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionCompteTier(int id)
		{
			await _repository.Delete(id);
		}
	}
}

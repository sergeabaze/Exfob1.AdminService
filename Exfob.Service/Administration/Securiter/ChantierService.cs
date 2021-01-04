using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ChantierService : IChantierService
	{

		private readonly IChantierRepository _repository;

		public ChantierService(IChantierRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Chantier>> ObtenireChantierListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Chantier> ObtenireChantierParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationChantier(Chantier entity)
		{
			await _repository.Creation(entity);
			return entity.ChantierID;
		}

		public async  Task MisejourChantier(Chantier entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionChantier(int id)
		{
			await _repository.Delete(id);
		}
	}
}

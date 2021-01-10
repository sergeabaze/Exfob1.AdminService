using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class NatureMouvementService : INatureMouvementService
	{

		private readonly INatureMouvementRepository _repository;

		public NatureMouvementService(INatureMouvementRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<NatureMouvement>> ObtenireNatureMouvementListe()
		{
			return await _repository.GetListe();
		}

		public async Task<NatureMouvement> ObtenireNatureMouvementParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationNatureMouvement(NatureMouvement entity)
		{
			await _repository.Creation(entity);
			return entity.NatureMouvementID;
		}

		public async  Task MisejourNatureMouvement(NatureMouvement entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionNatureMouvement(int id)
		{
			await _repository.Delete(id);
		}
	}
}

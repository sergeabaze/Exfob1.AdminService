using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class FamilleService : IFamilleService
	{

		private readonly IFamilleRepository _repository;

		public FamilleService(IFamilleRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Famille>> ObtenireFamilleListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Famille> ObtenireFamilleParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationFamille(Famille entity)
		{
			await _repository.Creation(entity);
			return entity.FamilleID;
		}

		public async  Task MisejourFamille(Famille entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionFamille(int id)
		{
			await _repository.Delete(id);
		}
	}
}

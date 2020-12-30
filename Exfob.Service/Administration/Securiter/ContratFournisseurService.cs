using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ContratFournisseurService : IContratFournisseurService
	{

		private readonly IContratFournisseurRepository _repository;

		public ContratFournisseurService(IContratFournisseurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ContratFournisseur>> ObtenireContratFournisseurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ContratFournisseur> ObtenireContratFournisseurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationContratFournisseur(ContratFournisseur entity)
		{
			await _repository.Creation(entity);
			return entity.ContratFournisseurID;
		}

		public async  Task MisejourContratFournisseur(ContratFournisseur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionContratFournisseur(int id)
		{
			await _repository.Delete(id);
		}
	}
}

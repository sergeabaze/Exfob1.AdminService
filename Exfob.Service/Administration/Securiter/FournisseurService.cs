using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class FournisseurService : IFournisseurService
	{

		private readonly IFournisseurRepository _repository;

		public FournisseurService(IFournisseurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Fournisseur>> ObtenireFournisseurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Fournisseur> ObtenireFournisseurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationFournisseur(Fournisseur entity)
		{
			await _repository.Creation(entity);
			return entity.FournisseurID;
		}

		public async  Task MisejourFournisseur(Fournisseur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionFournisseur(int id)
		{
			await _repository.Delete(id);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class LamelleCouleurService : ILamelleCouleurService
	{

		private readonly ILamelleCouleurRepository _repository;

		public LamelleCouleurService(ILamelleCouleurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<LamelleCouleur>> ObtenireLamelleCouleurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<LamelleCouleur> ObtenireLamelleCouleurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationLamelleCouleur(LamelleCouleur entity)
		{
			await _repository.Creation(entity);
			return entity.LamelleCouleurID;
		}

		public async  Task MisejourLamelleCouleur(LamelleCouleur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionLamelleCouleur(int id)
		{
			await _repository.Delete(id);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SousFamilleService : ISousFamilleService
	{

		private readonly ISousFamilleRepository _repository;

		public SousFamilleService(ISousFamilleRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<SousFamille>> ObtenireSousFamilleListe()
		{
			return await _repository.GetListe();
		}

		public async Task<SousFamille> ObtenireSousFamilleParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSousFamille(SousFamille entity)
		{
			await _repository.Creation(entity);
			return entity.SousFamilleID;
		}

		public async  Task MisejourSousFamille(SousFamille entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSousFamille(int id)
		{
			await _repository.Delete(id);
		}
	}
}

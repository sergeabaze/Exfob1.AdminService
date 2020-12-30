using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ModeEnvoieService : IModeEnvoieService
	{

		private readonly IModeEnvoieRepository _repository;

		public ModeEnvoieService(IModeEnvoieRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ModeEnvoie>> ObtenireModeEnvoieListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ModeEnvoie> ObtenireModeEnvoieParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationModeEnvoie(ModeEnvoie entity)
		{
			await _repository.Creation(entity);
			return entity.ModeEnvoieID;
		}

		public async  Task MisejourModeEnvoie(ModeEnvoie entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionModeEnvoie(int id)
		{
			await _repository.Delete(id);
		}
	}
}

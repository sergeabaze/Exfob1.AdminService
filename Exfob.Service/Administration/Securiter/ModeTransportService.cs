using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ModeTransportService : IModeTransportService
	{

		private readonly IModeTransportRepository _repository;

		public ModeTransportService(IModeTransportRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ModeTransport>> ObtenireModeTransportListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ModeTransport> ObtenireModeTransportParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationModeTransport(ModeTransport entity)
		{
			await _repository.Creation(entity);
			return entity.ModeTransportID;
		}

		public async  Task MisejourModeTransport(ModeTransport entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionModeTransport(int id)
		{
			await _repository.Delete(id);
		}
	}
}

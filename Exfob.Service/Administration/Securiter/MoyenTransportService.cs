using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class MoyenTransportService : IMoyenTransportService
	{

		private readonly IMoyenTransportRepository _repository;

		public MoyenTransportService(IMoyenTransportRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<MoyenTransport>> ObtenireMoyenTransportListe()
		{
			return await _repository.GetListe();
		}

		public async Task<MoyenTransport> ObtenireMoyenTransportParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationMoyenTransport(MoyenTransport entity)
		{
			await _repository.Creation(entity);
			return entity.MoyenTransportID;
		}

		public async  Task MisejourMoyenTransport(MoyenTransport entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionMoyenTransport(int id)
		{
			await _repository.Delete(id);
		}
	}
}

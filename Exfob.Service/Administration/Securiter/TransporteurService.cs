using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TransporteurService : ITransporteurService
	{

		private readonly ITransporteurRepository _repository;

		public TransporteurService(ITransporteurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Transporteur>> ObtenireTransporteurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Transporteur> ObtenireTransporteurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTransporteur(Transporteur entity)
		{
			await _repository.Creation(entity);
			return entity.TransporteurID;
		}

		public async  Task MisejourTransporteur(Transporteur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTransporteur(int id)
		{
			await _repository.Delete(id);
		}
	}
}

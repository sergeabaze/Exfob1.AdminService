using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TransitaireService : ITransitaireService
	{

		private readonly ITransitaireRepository _repository;

		public TransitaireService(ITransitaireRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Transitaire>> ObtenireTransitaireListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Transitaire> ObtenireTransitaireParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTransitaire(Transitaire entity)
		{
			await _repository.Creation(entity);
			return entity.TransitaireID;
		}

		public async  Task MisejourTransitaire(Transitaire entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTransitaire(int id)
		{
			await _repository.Delete(id);
		}
	}
}

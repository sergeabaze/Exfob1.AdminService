using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class CodificationService : ICodificationService
	{

		private readonly ICodificationRepository _repository;

		public CodificationService(ICodificationRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Codification>> ObtenireCodificationListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Codification> ObtenireCodificationParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationCodification(Codification entity)
		{
			await _repository.Creation(entity);
			return entity.CodificationID;
		}

		public async  Task MisejourCodification(Codification entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionCodification(int id)
		{
			await _repository.Delete(id);
		}
	}
}

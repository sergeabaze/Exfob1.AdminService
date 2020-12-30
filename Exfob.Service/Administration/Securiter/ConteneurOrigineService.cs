using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class ConteneurOrigineService : IConteneurOrigineService
	{

		private readonly IConteneurOrigineRepository _repository;

		public ConteneurOrigineService(IConteneurOrigineRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<ConteneurOrigine>> ObtenireConteneurOrigineListe()
		{
			return await _repository.GetListe();
		}

		public async Task<ConteneurOrigine> ObtenireConteneurOrigineParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationConteneurOrigine(ConteneurOrigine entity)
		{
			await _repository.Creation(entity);
			return entity.ContenaireOrigineID;
		}

		public async  Task MisejourConteneurOrigine(ConteneurOrigine entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionConteneurOrigine(int id)
		{
			await _repository.Delete(id);
		}
	}
}

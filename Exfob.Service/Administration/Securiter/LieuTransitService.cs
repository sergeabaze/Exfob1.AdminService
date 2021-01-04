using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class LieuTransitService : ILieuTransitService
	{

		private readonly ILieuTransitRepository _repository;

		public LieuTransitService(ILieuTransitRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<LieuTransit>> ObtenireLieuTransitListe()
		{
			return await _repository.GetListe();
		}

		public async Task<LieuTransit> ObtenireLieuTransitParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationLieuTransit(LieuTransit entity)
		{
			await _repository.Creation(entity);
			return entity.LieuTransitID;
		}

		public async  Task MisejourLieuTransit(LieuTransit entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionLieuTransit(int id)
		{
			await _repository.Delete(id);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class RotationService : IRotationService
	{

		private readonly IRotationRepository _repository;

		public RotationService(IRotationRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Rotation>> ObtenireRotationListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Rotation> ObtenireRotationParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationRotation(Rotation entity)
		{
			await _repository.Creation(entity);
			return entity.RotationID;
		}

		public async  Task MisejourRotation(Rotation entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionRotation(int id)
		{
			await _repository.Delete(id);
		}
	}
}

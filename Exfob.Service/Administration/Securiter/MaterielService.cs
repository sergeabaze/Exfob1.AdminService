using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class MaterielService : IMaterielService
	{

		private readonly IMaterielRepository _repository;

		public MaterielService(IMaterielRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<Materiel>> ObtenireMaterielListe()
		{
			return await _repository.GetListe();
		}

		public async Task<Materiel> ObtenireMaterielParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationMateriel(Materiel entity)
		{
			await _repository.Creation(entity);
			return entity.MaterielID;
		}

		public async  Task MisejourMateriel(Materiel entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionMateriel(int id)
		{
			await _repository.Delete(id);
		}
	}
}

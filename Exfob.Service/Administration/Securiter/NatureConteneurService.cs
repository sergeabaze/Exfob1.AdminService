using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class NatureConteneurService : INatureConteneurService
	{

		private readonly INatureConteneurRepository _repository;

		public NatureConteneurService(INatureConteneurRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<NatureConteneur>> ObtenireNatureConteneurListe()
		{
			return await _repository.GetListe();
		}

		public async Task<NatureConteneur> ObtenireNatureConteneurParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationNatureConteneur(NatureConteneur entity)
		{
			await _repository.Creation(entity);
			return entity.NatureConteneurID;
		}

		public async  Task MisejourNatureConteneur(NatureConteneur entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionNatureConteneur(int id)
		{
			await _repository.Delete(id);
		}
	}
}

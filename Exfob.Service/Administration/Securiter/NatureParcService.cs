using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class NatureParcService : INatureParcService
	{

		private readonly INatureParcRepository _repository;

		public NatureParcService(INatureParcRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<NatureParc>> ObtenireNatureParcListe()
		{
			return await _repository.GetListe();
		}

		public async Task<NatureParc> ObtenireNatureParcParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationNatureParc(NatureParc entity)
		{
			await _repository.Creation(entity);
			return entity.NatureParcID;
		}

		public async  Task MisejourNatureParc(NatureParc entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionNatureParc(int id)
		{
			await _repository.Delete(id);
		}
	}
}

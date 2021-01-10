using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class QualiteBoisService : IQualiteBoisService
	{

		private readonly IQualiteBoisRepository _repository;

		public QualiteBoisService(IQualiteBoisRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<QualiteBois>> ObtenireQualiteBoisListe()
		{
			return await _repository.GetListe();
		}

		public async Task<QualiteBois> ObtenireQualiteBoisParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationQualiteBois(QualiteBois entity)
		{
			await _repository.Creation(entity);
			return entity.QualiteBoisID;
		}

		public async  Task MisejourQualiteBois(QualiteBois entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionQualiteBois(int id)
		{
			await _repository.Delete(id);
		}
	}
}

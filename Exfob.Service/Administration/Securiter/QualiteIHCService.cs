using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class QualiteIHCService : IQualiteIHCService
	{

		private readonly IQualiteIHCRepository _repository;

		public QualiteIHCService(IQualiteIHCRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<QualiteIHC>> ObtenireQualiteIHCListe()
		{
			return await _repository.GetListe();
		}

		public async Task<QualiteIHC> ObtenireQualiteIHCParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationQualiteIHC(QualiteIHC entity)
		{
			await _repository.Creation(entity);
			return entity.QualiteIHCID;
		}

		public async  Task MisejourQualiteIHC(QualiteIHC entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionQualiteIHC(int id)
		{
			await _repository.Delete(id);
		}
	}
}

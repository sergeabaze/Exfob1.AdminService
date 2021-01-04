using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class CodePlaquetteService : ICodePlaquetteService
	{

		private readonly ICodePlaquetteRepository _repository;

		public CodePlaquetteService(ICodePlaquetteRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<CodePlaquette>> ObtenireCodePlaquetteListe()
		{
			return await _repository.GetListe();
		}

		public async Task<CodePlaquette> ObtenireCodePlaquetteParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationCodePlaquette(CodePlaquette entity)
		{
			await _repository.Creation(entity);
			return entity.CodePlaquetteID;
		}

		public async  Task MisejourCodePlaquette(CodePlaquette entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionCodePlaquette(int id)
		{
			await _repository.Delete(id);
		}
	}
}

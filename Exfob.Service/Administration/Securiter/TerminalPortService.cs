using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class TerminalPortService : ITerminalPortService
	{

		private readonly ITerminalPortRepository _repository;

		public TerminalPortService(ITerminalPortRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<TerminalPort>> ObtenireTerminalPortListe()
		{
			return await _repository.GetListe();
		}

		public async Task<TerminalPort> ObtenireTerminalPortParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationTerminalPort(TerminalPort entity)
		{
			await _repository.Creation(entity);
			return entity.TerminalPortID;
		}

		public async  Task MisejourTerminalPort(TerminalPort entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionTerminalPort(int id)
		{
			await _repository.Delete(id);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public class SocieteMaritimeService : ISocieteMaritimeService
	{

		private readonly ISocieteMaritimeRepository _repository;

		public SocieteMaritimeService(ISocieteMaritimeRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<IEnumerable<SocieteMaritime>> ObtenireSocieteMaritimeListe()
		{
			return await _repository.GetListe();
		}

		public async Task<SocieteMaritime> ObtenireSocieteMaritimeParId(int Id)
		{
			return await _repository.GetById(Id);
		}

		public async  Task<int> CreationSocieteMaritime(SocieteMaritime entity)
		{
			await _repository.Creation(entity);
			return entity.SocieteMaritimeID;
		}

		public async  Task MisejourSocieteMaritime(SocieteMaritime entity)
		{
			await _repository.Update(entity);
		}

		public async  Task SuppressionSocieteMaritime(int id)
		{
			await _repository.Delete(id);
		}
	}
}

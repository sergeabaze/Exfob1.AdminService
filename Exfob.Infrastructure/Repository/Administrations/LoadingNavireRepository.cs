using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
using Exfob.Core.Interfaces.Repository;
namespace Exfob.Infrastructure.Repository
{
	public  class LoadingNavireRepository : GenericRepository<LoadingNavire>, ILoadingNavireRepository
	{
		private GestionBoisContext _dBContext;
		#region Constructor
		public LoadingNavireRepository(GestionBoisContext context)
		   : base(context)
		{
			_dBContext = context;
		}

		#endregion

		#region Public methods
		public async  Task<LoadingNavire> GetById(int Id)
		{
			return await this.GetByIdAsync(Id);
		}

		public async  Task<IEnumerable<LoadingNavire>> GetListe()
		{
			return await this.GetAllAsync();
		}

		public async  Task<int> Creation(LoadingNavire entity)
		{
			if (entity == null) throw new Exception("On ne peut modifier un objet nul.");
			await this.AddAsync(entity, true);
			return entity.LoadingNavireID ;
		}

		public async  Task Update(LoadingNavire entity)
		{
		if (entity == null) throw new Exception("Erreur. Objet nul détecté");
		await this.UpdateAsync(entity, true);
		}
		public async  Task Delete(int id)
		{
			await this.DeleteAsync(id, true);
		}

		#endregion
	}
}

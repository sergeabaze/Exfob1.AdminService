using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Models.Administration;
using Exfob.Core.Interfaces.Repository;
namespace Exfob.Infrastructure.Repository
{
	public  class SectionAnalytiqueRepository : GenericRepository<SectionAnalytique>, ISectionAnalytiqueRepository
	{
		private GestionBoisContext _dBContext;
		#region Constructor
		public SectionAnalytiqueRepository(GestionBoisContext context)
		   : base(context)
		{
			_dBContext = context;
		}

		#endregion

		#region Public methods
		public async  Task<SectionAnalytique> GetById(int Id)
		{
			return await this.GetByIdAsync(Id);
		}

		public async  Task<IEnumerable<SectionAnalytique>> GetListe()
		{
			return await this.GetAllAsync();
		}

		public async  Task<int> Creation(SectionAnalytique entity)
		{
			if (entity == null) throw new Exception("On ne peut modifier un objet nul.");
			await this.AddAsync(entity, true);
			return entity.SectionAnalytiqueID ;
		}

		public async  Task Update(SectionAnalytique entity)
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

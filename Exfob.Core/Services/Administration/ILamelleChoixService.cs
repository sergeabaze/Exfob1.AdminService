using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface ILamelleChoixService
	{
		Task<IEnumerable<LamelleChoix>> ObtenireLamelleChoixListe();
		Task<LamelleChoix> ObtenireLamelleChoixParId(int Id);
		Task<int> CreationLamelleChoix(LamelleChoix entity);
		Task MisejourLamelleChoix(LamelleChoix entity);
		Task SuppressionLamelleChoix(int id);

	}
}

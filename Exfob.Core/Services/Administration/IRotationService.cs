using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exfob.Core.Interfaces.Repository;
using Exfob.Models.Administration;
namespace Exfob.Core.Services.Administration
{
	public  interface IRotationService
	{
		Task<IEnumerable<Rotation>> ObtenireRotationListe();
		Task<Rotation> ObtenireRotationParId(int Id);
		Task<int> CreationRotation(Rotation entity);
		Task MisejourRotation(Rotation entity);
		Task SuppressionRotation(int id);

	}
}

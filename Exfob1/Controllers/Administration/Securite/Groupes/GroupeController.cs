using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Exfob1.Models.Adminstrations;
using Exfob1.Conventions;
using Exfob1.Models;
namespace Exfob1.Controllers.Administration
{	[Route("api/groupes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class GroupeController : ControllerBase
	{

		private readonly IGroupeBLL _groupeBLL;
		private readonly ILogger<GroupeController> _logger;
		public GroupeController(IGroupeBLL groupeBLL, ILogger<GroupeController> logger)
		{
			_groupeBLL = groupeBLL ?? throw new ArgumentNullException(nameof(groupeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<GroupeListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _groupeBLL.ObtenireGroupeListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id groupe</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<GroupeReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _groupeBLL.ObtenireGroupeParId(id)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de création
		/// </summary>
		/// <param name="request">objet</param>
		/// <returns>objet créer</returns>
		[HttpPost("creation")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<GroupeReponse>>> CreationAsync([FromBody] GroupeRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<GroupeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _groupeBLL.CreationGroupe(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="groupeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{groupeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<GroupeReponse>>> MisejourAsync(int groupeid, [FromBody] GroupeEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<GroupeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _groupeBLL.MisejourGroupe(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="groupeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{groupeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<GroupeReponse>>> SuppressionAsync(int groupeid)
		{
			var response = await _groupeBLL.SuppressionGroupe(groupeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}

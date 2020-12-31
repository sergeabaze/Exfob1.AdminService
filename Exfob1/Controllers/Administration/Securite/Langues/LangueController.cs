using Exfob1.Controllers.Administration.Securite.Langues.BusinessLogic;
using Exfob1.Conventions;
using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration.Securite.Langues
{
    [Route("api/langues")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class LangueController : ControllerBase
    {

        private readonly ILangueBLL _langueBLL;
        private readonly ILogger<LangueController> _logger;
        public LangueController(ILangueBLL langueBLL, ILogger<LangueController> logger)
        {
            _langueBLL = langueBLL ?? throw new ArgumentNullException(nameof(langueBLL));
            _logger = logger;
        }

        /// <summary>
        /// liste 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>retourne collection</returns>
        [HttpGet("list")]
        
        [ProducesResponseType(StatusCodes.Status404NotFound)]
      
        public async Task<ActionResult<WebApiListResponse<LangueListe>>> obtenireListeAsync(CancellationToken cancellationToken)
        {
            var response = await _langueBLL.ObtenireLangueListe()
                .ConfigureAwait(false);
           
            return response.ToHttpResponse();
        }

        /// <summary>
        /// obtenire par id
        /// </summary>
        /// <param name="id">id langue</param>
        /// <returns>retourne objet</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiSingleResponse<LangueReponse>>> obtenireParIdAsync(int id)
        {
            var response = await _langueBLL.ObtenireLangueParId(id)
                .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// fonction de creation
        /// </summary>
        /// <param name="request">objet</param>
        /// <returns>objet creer</returns>
        [HttpPost("creation")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiConventionMethod(typeof(CustomsConventions),
          nameof(CustomsConventions.Insert))]
        public async Task<ActionResult<WebApiSingleResponse<LangueReponse>>> CreationAsync([FromBody] LangueRequest request)
        {

            if (!ModelState.IsValid)
            {
                var repo = new WebApiListResponse<LangueReponse>
                {
                    CodeMessage = StatusCodes.Status400BadRequest,
                    IsError = true,
                    ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };

                return repo.ToHttpResponse();
            }
            var response = await _langueBLL.CreationLangue(request)
            .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// fonction de misejour
        /// </summary>
        /// <param name="langueid">id</param>
        /// <param name="request">objet</param>
        /// <returns>objet misejour</returns>
        [HttpPut("edit/{langueid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiConventionMethod(typeof(CustomsConventions),
          nameof(CustomsConventions.Insert))]
        public async Task<ActionResult<WebApiSingleResponse<LangueReponse>>> MisejourAsync(int langueid, [FromBody] LangueEdit request)
        {

            if (!ModelState.IsValid)
            {
                var repo = new WebApiListResponse<LangueReponse>
                {
                    CodeMessage = StatusCodes.Status400BadRequest,
                    IsError = true,
                    ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };
                return repo.ToHttpResponse();
            }
            var response = await _langueBLL.MisejourLangue(request)
            .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// fonction de suppression
        /// </summary>
        /// <param name="langueid">id</param>
        /// <returns>status</returns>
        [HttpDelete("suppression/{langueid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiConventionMethod(typeof(CustomsConventions),
         nameof(CustomsConventions.Insert))]
        public async Task<ActionResult<WebApiSingleResponse<LangueReponse>>> SuppressionAsync(int langueid)
        {
            var response = await _langueBLL.SuppressionLangue(langueid)
            .ConfigureAwait(false);

            return response.ToHttpResponse();
        }
    }
}

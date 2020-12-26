using Exfob1.Controllers.Administration.Securite.Langues.BusinessLogic;
using Exfob1.Controllers.Administration.Securite.Profiles.BusinessLogic;
using Exfob1.Conventions;
using Exfob1.Models;
using Exfob1.Models.Adminstrations.Profiles.Request;
using Exfob1.Models.Adminstrations.Profiles.ResPonse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exfob1.Controllers.Administration.Securite.Profiles
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileBLL _profileBLL;
        private readonly ILogger<ProfileController> _logger;
        public ProfileController(IProfileBLL profileBLL, ILogger<ProfileController> logger)
        {
            _profileBLL = profileBLL ?? throw new ArgumentNullException(nameof(profileBLL));
            _logger = logger;
        }

        /// <summary>
        /// liste
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>retourne collection</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiListResponse<ProfileListe>>> obtenireListeAsync(CancellationToken cancellationToken)
        {
            var response = await _profileBLL.ObtenireProfileListe()
                .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// obtenire par id
        /// </summary>
        /// <param name="id">id profile</param>
        /// <returns>retourne objet</returns>
        /// <response code="200">Si retourne un objet </response>
        /// <response code="404">Si le lobjet nexiste pas</response>
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiSingleResponse<ProfileResponse>>> obtenireParIdAsync(int id)
        {
            var response = await _profileBLL.ObtenireProfileParId(id)
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
        public async Task<ActionResult<WebApiSingleResponse<ProfileResponse>>> CrationAsync([FromBody] ProfileRequest request)
        {

            if (!ModelState.IsValid)
            {
              var repo =  new WebApiListResponse<ProfileResponse>
                {
                    CodeMessage = StatusCodes.Status400BadRequest,
                    IsError = true,
                    ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };
                return repo.ToHttpResponse();
            }
                var response = await _profileBLL.CreationProfile(request)
                .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// fonction de misejour
        /// </summary>
        /// <param name="profileid">id</param>
        /// <param name="request">objet</param>
        /// <returns>objet misejour</returns>
        [HttpPut("edition/{profileid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiConventionMethod(typeof(CustomsConventions),
          nameof(CustomsConventions.Insert))]
        public async Task<ActionResult<WebApiSingleResponse<ProfileResponse>>> MisejourAsync(int profileid, [FromBody] ProfileEdit request)
        {

            if (!ModelState.IsValid)
            {
                var repo = new WebApiListResponse<ProfileResponse>
                {
                    CodeMessage = StatusCodes.Status400BadRequest,
                    IsError = true,
                    ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };

                return repo.ToHttpResponse();
            }

            var response = await _profileBLL.MisejourProfile(request)
            .ConfigureAwait(false);

            return response.ToHttpResponse();
        }

        /// <summary>
        /// fonction de suppression
        /// </summary>
        /// <param name="profileid">id</param>
        /// <returns>status</returns>
        [HttpDelete("suppression/{profileid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiConventionMethod(typeof(CustomsConventions),
         nameof(CustomsConventions.Insert))]
        public async Task<ActionResult<WebApiSingleResponse<ProfileResponse>>> SuppressionAsync(int profileid)
        {
            var response = await _profileBLL.SuppressionProfile(profileid)
            .ConfigureAwait(false);

            return response.ToHttpResponse();
        }
    }
}

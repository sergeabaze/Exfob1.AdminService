using AutoFixture.Xunit2;
using Exfob1.Controllers.Administration.Securite.Profiles;
using Exfob1.Controllers.Administration.Securite.Profiles.BusinessLogic;
using Exfob1.Models;
using Exfob1.Models.Adminstrations;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Profiles
{
    public  class ProfileControllerTests
    {
        public class CallInnerList
        {
            [Theory, UnitTestConventions]
            public async Task ObtenireListOnOkResult([Frozen] IProfileBLL businesslogic, ProfileListe profile, ProfileController sut)
            {
                //Arrang
                var profileListe = new List<ProfileListe> { profile };
                var result = new WebApiListResponse<ProfileListe>
                {
                    IsError = false,
                    CodeMessage = StatusCodes.Status200OK,
                    Model = profileListe
                };
                var _businesslogicMock = Mock.Get(businesslogic);


                _businesslogicMock.Setup(bll => bll.ObtenireProfileListe())
                    .ReturnsAsync(result);

                //Act
                var httpRequest = await sut.obtenireListeAsync(CancellationToken.None);

                //Assert
                var okResult = Assert.IsType<OkObjectResult>(httpRequest.Result);
                okResult.StatusCode.Should().Be(result.CodeMessage);

                _businesslogicMock.Verify(bll => bll.ObtenireProfileListe(), Times.Once);
            }
        }
    }
}

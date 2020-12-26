using AutoFixture.Xunit2;
using AutoMapper;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using Exfob.Models.Fakes;
using Exfob1.Controllers.Administration.Securite.Langues.BusinessLogic;
using Exfob1.Controllers.Administration.Securite.Profiles.BusinessLogic;
using Exfob1.Models.Adminstrations.Profiles.ResPonse;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Profiles
{
    public   class ProfileBLLTests
    {
        public class CallInnerList
        {
            [Theory, UnitTestConventions]
            public async Task ObtenireListOnOkResult([Frozen] IProfileService service,
               [Frozen] IMapper mapper,
                ProfileListe model,
               ProfileBLL sut)
            {
                //Arrang
                GestionBoisDataTestesFakes fakes = new GestionBoisDataTestesFakes();
                var entityListe = new List<Profil> { fakes.GetProfil() };
                var modelListe = new List<ProfileListe> { model };

                var _serviceMock = Mock.Get(service);
                var mockMapper = Mock.Get(mapper);


                _serviceMock.Setup(svce => svce.ObtenireProfileListe())
                    .ReturnsAsync(entityListe);

                mockMapper.Setup(x => x.Map<IEnumerable<ProfileListe>>(entityListe))
                    .Returns(modelListe.AsEnumerable());

                //Act
                var result = await sut.ObtenireProfileListe();

                //Assert
                Assert.NotNull(result);
                _serviceMock.Verify(bll => bll.ObtenireProfileListe(), Times.Once);
            }

        }
        }
}

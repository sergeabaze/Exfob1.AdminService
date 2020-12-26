using AutoFixture.Xunit2;
using Exfob.Core.Interfaces.Administrations.Securites;
using Exfob.Core.Services.Administration;
using Exfob.Models.Administration;
using Exfob.Service.Administration.Securiter;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exfob.Service.Tests.Administration.Securiter
{
   public  class LangueServiceTests
    {

        [Theory, UniTestsConvention]
        public async Task Call_ObtenireLangueListe_Should_return_List([Frozen] ILangueRepository repository, LangueService sut)
        {
            //Arrang
            var langueMock = Mock.Get(repository);
            var langue = new Langue { LangueID = 1, Code = "Code123", Libelle = "Libelle123" };
            var langues = new List<Langue> { langue };

            langueMock.Setup(x => x.GetListe())
                .ReturnsAsync(langues.AsEnumerable());

            //act
            var result = await  sut.ObtenireLangueListe();

            //Assert
            Assert.NotNull(result);
            langueMock.Verify(x => x.GetListe(), Times.Once);
        }

        [Theory, UniTestsConvention]
        public async Task Call_ObtenireLangueParId_Should_return_object([Frozen] ILangueRepository repository,
            int Id,
            LangueService sut)
        {
            //Arrang
            var langueMock = Mock.Get(repository);
            var langue = new Langue { LangueID = 1, Code = "Code123", Libelle = "Libelle123" };
           

            langueMock.Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(langue);

            //act
            var result = await sut.ObtenireLangueParId(Id);

            //Assert
            Assert.NotNull(result);
            langueMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Theory, UniTestsConvention]
        public async Task Call_ObtenireLangueParId_NotFound_Should_return_null(
            [Frozen] ILangueRepository repository,
           int Id,
           LangueService sut)
        {
            //Arrang
            var langueMock = Mock.Get(repository);

            langueMock.Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync((Langue)null);

            //act
            var result = await sut.ObtenireLangueParId(Id);

            //Assert
            Assert.Null(result);
            langueMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Theory, UniTestsConvention]
        public async Task Call_CreationLangue_Should_return_object([Frozen] ILangueRepository repository,
           LangueService sut)
        {
            //Arrang
            var langueMock = Mock.Get(repository);
            var langue = new Langue { LangueID = 1, Code = "Code123", Libelle = "Libelle123" };


            langueMock.Setup(x => x.Creation(It.IsAny<Langue>()))
                .ReturnsAsync(1);

            //act
            var result = await sut.CreationLangue(langue);

            //Assert
            Assert.Equal(1, result);
            langueMock.Verify(x => x.Creation(It.IsAny<Langue>()), Times.Once);
        }

        [Theory, UniTestsConvention]
        public async Task Call_MisejourLangue_Should_return([Frozen] ILangueRepository repository,
          LangueService sut)
        {
            //Arrang
            var langueMock = Mock.Get(repository);
            var langue = new Langue { LangueID = 1, Code = "Code123", Libelle = "Libelle123" };

            //act
             await sut.MisejourLangue(langue);

            //Assert
           
            langueMock.Verify(x => x.Update(It.IsAny<Langue>()), Times.Once);
        }

        [Theory, UniTestsConvention]
        public async Task Call_SuppressionLangue_Should_return([Frozen] ILangueRepository repository,
         int Id,
         LangueService sut)
        {
            //Arrang
            var langueMock = Mock.Get(repository);

            //act
            await sut.SuppressionLangue(Id);

            //Assert

            langueMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}

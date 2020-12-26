using Exfob1.Models.Adminstrations.Langues.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Langues
{
    public  class LangueEditTests
    {
        private ValidationContext CreateContext(LangueEdit model) => new ValidationContext(model, null, null);

        [Theory, UnitTestConventions]
        public void Should_Return_TrueValid_WhenRulesOk(LangueEdit sut)
        {
           
            var results = new List<ValidationResult>();

            Assert.True(Validator.TryValidateObject(sut, CreateContext(sut), results));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_Code_Invald(LangueEdit sut)
        {
            sut.Code = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(LangueEdit.Code))));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_Libelle_Invald(LangueEdit sut)
        {
            sut.Libelle = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(LangueEdit.Libelle))));
        }
    }
}

﻿using Exfob1.Models.Adminstrations.Langues.Request;
using Exfob1.Models.Adminstrations.Profiles.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Exfob1.Tests.Administration.Securiter.Profiles
{
   public  class ProfileEditTests
    {
        private ValidationContext CreateContext(ProfileEdit model) => new ValidationContext(model, null, null);

        [Theory, UnitTestConventions]
        public void Should_Return_TrueValid_WhenRulesOk(ProfileEdit sut)
        {

            var results = new List<ValidationResult>();

            Assert.True(Validator.TryValidateObject(sut, CreateContext(sut), results));
        }

        [Theory, UnitTestConventions]
        public void Should_Return_False_When_Code_Invald(ProfileEdit sut)
        {
            sut.Libelle = null;
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, CreateContext(sut), results));
            Assert.NotNull(results.FirstOrDefault(r => r.MemberNames.Contains(nameof(ProfileEdit.Libelle))));
        }
    }
}
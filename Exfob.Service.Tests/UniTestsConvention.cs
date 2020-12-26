using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exfob.Service.Tests
{
  public   class UniTestsConvention : AutoDataAttribute
    {
        public UniTestsConvention() : base(CreationFixture)
        {

        }

        private static IFixture CreationFixture()
        {
            var fixture = new AutoFixture.Fixture()
                .Customize(new CompositeCustomization(
                         new AutoMoqCustomization(),
                            new SupportMutableValueTypesCustomization()));

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b =>
                fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        }
    }
}

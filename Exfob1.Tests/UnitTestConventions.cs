using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Exfob1.Tests.Fixtures;

namespace Exfob1.Tests
{
    public class UnitTestConventions : AutoDataAttribute
    {
        public UnitTestConventions() : base(CreateFixture)
        {
        }

        private static IFixture CreateFixture()
        {
            return new Fixture()
                .Customize(new ControllerBaseCustomizations())
                .Customize(new AutoMoqCustomization());
        }
    }
}

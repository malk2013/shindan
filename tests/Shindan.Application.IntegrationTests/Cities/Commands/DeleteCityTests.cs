using System.Threading.Tasks;
using Shindan.Application.Cities.Commands.Create;
using Shindan.Application.Cities.Commands.Delete;
using Shindan.Application.Common.Exceptions;
using Shindan.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static Shindan.Application.IntegrationTests.Testing;

namespace Shindan.Application.IntegrationTests.Cities.Commands
{
    public class DeleteCityTests : TestBase
    {
        [Test]
        public void ShouldRequireValidCityId()
        {
            var command = new DeleteCityCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteCity()
        {
            var city = await SendAsync(new CreateCityCommand
            {
                Name = "Kayseri"
            });

            await SendAsync(new DeleteCityCommand
            {
                Id = city.Data.Id
            });

            var list = await FindAsync<City>(city.Data.Id);

            list.Should().BeNull();
        }
    }
}

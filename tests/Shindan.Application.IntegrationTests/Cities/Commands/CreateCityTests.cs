using System;
using System.Threading.Tasks;
using Shindan.Application.Cities.Commands.Create;
using Shindan.Application.Common.Exceptions;
using Shindan.Domain.Entities;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using static Shindan.Application.IntegrationTests.Testing;

namespace Shindan.Application.IntegrationTests.Cities.Commands
{
    public class CreateCityTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateCityCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();

        }

        [Test]
        public async Task ShouldRequireUniqueName()
        {
            await SendAsync(new CreateCityCommand
            {
                Name = "Bursa"
            });

            var command = new CreateCityCommand
            {
                Name = "Bursa"
            };

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateCity()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateCityCommand
            {
                Name = "Kastamonu"
            };

            var result = await SendAsync(command);

            var list = await FindAsync<City>(result.Data.Id);

            list.Should().NotBeNull();
            list.Name.Should().Be(command.Name);
            list.Creator.Should().Be(userId);
            list.CreateDate.Should().BeCloseTo(DateTime.Now, 10.Seconds());
        }
    }
}

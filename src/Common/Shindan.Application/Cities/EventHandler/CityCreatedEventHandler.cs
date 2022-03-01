using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shindan.Application.Common.Interfaces;
using Shindan.Application.Common.Models;
using Shindan.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Shindan.Application.Cities.EventHandler
{
    public class CityCreatedEventHandler : INotificationHandler<DomainEventNotification<CityCreatedEvent>>
    {
        private readonly ILogger<CityActivatedEventHandler> _logger;
        private readonly IEmailService _emailService;

        public CityCreatedEventHandler(ILogger<CityActivatedEventHandler> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task Handle(DomainEventNotification<CityCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Shindan Shindan.Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            if (domainEvent.City != null)
            {
                await _emailService.SendAsync(new EmailRequest
                {
                    Subject = domainEvent.City.Name + " is created.",
                    Body = "City is created successfully.",
                    FromDisplayName = "Clean Architecture",
                    FromMail = "test@test.com",
                    ToMail = new List<string> { "to@test.com" }
                });
            }
        }
    }
}

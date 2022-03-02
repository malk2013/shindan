using System.Threading.Tasks;
using Shindan.Domain.Common;

namespace Shindan.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}

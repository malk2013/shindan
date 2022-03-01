using System.Threading.Tasks;
using Shindan.Application.Common.Models;

namespace Shindan.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}

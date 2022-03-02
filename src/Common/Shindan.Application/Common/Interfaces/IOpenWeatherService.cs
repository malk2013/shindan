using System.Threading;
using System.Threading.Tasks;
using Shindan.Application.Common.Models;
using Shindan.Application.ExternalServices.OpenWeather.Request;
using Shindan.Application.ExternalServices.OpenWeather.Response;

namespace Shindan.Application.Common.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
            CancellationToken cancellationToken);
    }
}
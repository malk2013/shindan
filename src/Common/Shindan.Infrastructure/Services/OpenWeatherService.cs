using System.Threading;
using System.Threading.Tasks;
using Shindan.Application.Common.Interfaces;
using Shindan.Application.Common.Mapping;
using Shindan.Application.Common.Models;
using Shindan.Application.ExternalServices.OpenWeather.Request;
using Shindan.Application.ExternalServices.OpenWeather.Response;
using Shindan.Domain.Enums;

namespace Shindan.Infrastructure.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "open-weather-api";

        public OpenWeatherService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi, string.Concat("weather?", StringExtensions
                .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        }
    }
}
using System;
using Shindan.Application.Common.Interfaces;

namespace Shindan.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

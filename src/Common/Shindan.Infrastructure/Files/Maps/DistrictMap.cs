using System.Globalization;
using Shindan.Application.Dto;
using CsvHelper.Configuration;

namespace Shindan.Infrastructure.Files.Maps
{
    public sealed class DistrictMap : ClassMap<DistrictDto>
    {
        public DistrictMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Villages).Convert(_ => "");
        }
    }
}

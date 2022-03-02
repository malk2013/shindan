using System.Collections.Generic;
using Shindan.Application.Dto;

namespace Shindan.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildDistrictsFile(IEnumerable<DistrictDto> districts);
    }
}

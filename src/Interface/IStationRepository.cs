using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationService.src.StationDto;

namespace stationService.src.Interface
{
    public interface IStationRepository
    {
        public Task<ResponseStationDto> CreateStation(CreateStationDto request);

        public Task<List<ResponseStationDto>> GetStations(string? Name, string? Type, bool? State);

        public Task<ResponseStationDto> GetStationById(Guid ID);

        public Task EditStation(Guid ID, EditStationDto request);

        public Task DisabledEnabledStation(Guid ID);
    }
}
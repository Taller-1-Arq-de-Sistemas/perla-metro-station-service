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

        public Task<List<ResponseStationDto>> GetStations();

        public Task<ResponseStationDto> GetStationById(Guid ID);
    }
}
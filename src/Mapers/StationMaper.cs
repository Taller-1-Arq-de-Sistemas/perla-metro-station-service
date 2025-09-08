using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationService.src.Model;
using stationService.src.StationDto;

namespace stationService.src.Mapers
{
    public static class StationMaper
    {
        public static ResponseStationDto ToStationResponse(this Station station)
        {
            return new ResponseStationDto
            {
                ID = station.ID,
                NameStation = station.NameStation,
                Location = station.Location,
                Type = station.Type,
                State = station.State
            };
            

        }
    }
}
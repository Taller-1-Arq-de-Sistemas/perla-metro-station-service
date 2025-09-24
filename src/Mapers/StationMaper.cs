using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationService.src.DTO;
using stationService.src.Model;
using stationService.src.StationDto;

namespace stationService.src.Mapers
{
    /// <summary>
    /// Clase  para mapear la entidad Station a DTOs
    /// Proporciona metodos de extension para conversion de objetos
    /// </summary>
    public static class StationMaper
    {
        /// <summary>
        /// Convierte una entidad Station a un DTO de respuesta
        /// Metodo de extensión que mapea todos los campos de la entidad al DTO
        /// </summary>
        /// <param name="station">Entidad Station a convertir</param>
        /// <returns>DTO de respuesta con los datos de la estacion</returns>
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


        /// <summary>
        /// Convierte una entidad Station a un DTO de respuesta
        /// Metodo de extensión que mapea todos los campos de la entidad al DTO
        /// </summary>
        /// <param name="station">Entidad Station a convertir</param>
        /// <returns>DTO de respuesta con los datos de la estacion</returns>
        public static ResponseStationByIdDto ToStationByIdResponse(this Station station)
        {
            return new ResponseStationByIdDto
            {
                ID = station.ID,
                NameStation = station.NameStation,
                Location = station.Location,
                Type = station.Type,
            };
        }

    }
}
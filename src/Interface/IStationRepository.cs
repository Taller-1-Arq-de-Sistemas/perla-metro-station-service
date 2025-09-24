using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationService.src.DTO;
using stationService.src.StationDto;

namespace stationService.src.Interface
{
    /// <summary>
    /// Interfaz del repositorio de estaciones
    /// Define la forma en que se obtiene y gestiona la informacion de estaciones
    /// </summary>
    public interface IStationRepository
    {
        /// <summary>
        /// Crea una nueva estación en el sistema
        /// </summary>
        /// <param name="request">Datos de la estación a crear</param>
        /// <returns>DTO con la información de la estación creada</returns>
        public Task<ResponseStationDto> CreateStation(CreateStationDto request);

        /// <summary>
        /// Obtiene una listado de estaciones con filtros opcionales
        /// </summary>
        /// <param name="Name">Filtro opcional por nombre de estacion</param>
        /// <param name="Type">Filtro opcional por tipo de estacion</param>
        /// <param name="State">Filtro opcional por estado de la estacion</param>
        /// <returns>Lista de estaciones que coinciden con los filtros aplicados</returns>
        public Task<List<ResponseStationDto>> GetStations(string? Name, string? Type, bool? State);

        /// <summary>
        /// Obtiene una estacion especifica por su identificador unico
        /// </summary>
        /// <param name="ID">ID de la estacion</param>
        /// <returns>DTO con la información de la estacion solicitada</returns>
        public Task<ResponseStationByIdDto> GetStationById(Guid ID);

        /// <summary>
        /// Edita los datos de una estación existente
        /// </summary>
        /// <param name="ID">ID de la estacion a editar</param>
        /// <param name="request">Nuevos datos para actualizar la estación</param>
        /// <returns>Tarea que representa la operación asíncrona de edición</returns>
        public Task EditStation(Guid ID, EditStationDto request);

        /// <summary>
        /// Cambia el estado de una estacion (Activa/Inactiva)
        /// Implementa soft delte reversible
        /// </summary>
        /// <param name="ID">ID de la estación</param>
        /// <returns>Tarea que representa la operación asincrona de cambio de estado</returns>
        public Task DisabledEnabledStation(Guid ID);
    }
}
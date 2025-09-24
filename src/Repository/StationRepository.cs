using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stationService.src.Data;
using stationService.src.DTO;
using stationService.src.Helper;
using stationService.src.Interface;
using stationService.src.Mapers;
using stationService.src.Model;
using stationService.src.StationDto;

namespace stationService.src.Repository
{
    /// <summary>
    /// Implementacion de patron Repository utilizado para encapsular las operaciones con la base de datos
    /// Maneja el acceso a datos y lógica de negocio para las estaciones
    /// </summary>
    public class StationRepository : IStationRepository
    {
        private readonly DBContext _context;

        /// <summary>
        /// Constructor del repositorio de estaciones
        /// </summary>
        /// <param name="context">Contexto de base de datos para operaciones </param>
        public StationRepository(DBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea una nueva estacion en el sistema
        /// Valida que no exista una estación con el mismo nombre o ubicación
        /// </summary>
        /// <param name="request">Datos de la estacion a crear</param>
        /// <returns>DTO con la información de la estacion creada</returns>
        public async Task<ResponseStationDto> CreateStation(CreateStationDto request)
        {

            var exist = await _context.Stations.FirstOrDefaultAsync(s => s.NameStation.ToLower().Trim() == request.NameStation.ToLower().Trim() || s.Location.ToLower().Trim() == request.Location.ToLower().Trim());

            if (exist != null)
            {

                if (exist.NameStation.ToLower().Trim() == request.NameStation.ToLower().Trim() && exist.Location.ToLower().Trim() == request.Location.ToLower().Trim())
                {
                    throw new Exception("Error. Estación ya existente");
                }

                if (exist.NameStation.ToLower().Trim() == request.NameStation.ToLower().Trim())
                {
                    throw new Exception("Error. Ya existe una estación con este nombre");
                }
                else if (exist.Location.ToLower().Trim() == request.Location.ToLower().Trim())
                {
                    throw new Exception("Error. Ya existe una estación con esta Ubicacion");
                }
            }

            var StationRequest = new Station
            {

                NameStation = request.NameStation,
                Location = request.Location,
                Type = request.Type,
                State = true
            };


            await _context.Stations.AddAsync(StationRequest);
            await _context.SaveChangesAsync();


            var response = StationRequest.ToStationResponse();
            return response;
        }

        /// <summary>
        /// Obtiene una listado de estaciones aplicando filtros opcionales
        /// </summary>
        /// <param name="Name">Filtro opcional por nombre de estacion</param>
        /// <param name="Type">Filtro opcional por tipo de estacion</param>
        /// <param name="State">Filtro opcional por estado de la estacion</param>
        /// <returns>Listado de estaciones que coinciden con los filtros aplicados</returns>
        public async Task<List<ResponseStationDto>> GetStations(string? Name, string? Type, bool? State)
        {
            var query = _context.Stations.AsQueryable();


            query = StationFilterHelper.Filters(query, Name, Type, State);


            var Stations = await query.Select(s => s.ToStationResponse()).ToListAsync();

            if (Stations.Count == 0)
            {
                throw new Exception("Error. No se encontraron Estaciones");
            }

            return Stations;
        }

        /// <summary>
        /// Obtiene una estacion especofica por su ID
        /// Solo retorna estaciones activas (State = true)
        /// </summary>
        /// <param name="ID">Identificador único de la estación</param>
        /// <returns>DTO con la informacion de la estacion solicitada</returns>
        public async Task<ResponseStationByIdDto> GetStationById(Guid ID)
        {
            
            var Station = await _context.Stations.FirstOrDefaultAsync(s => s.ID == ID && s.State == true);

            if (Station == null)
            {
                throw new Exception("Error. Estacion no encontrada");
            }

            var response = Station.ToStationByIdResponse();
            return response;
        }

        /// <summary>
        /// Edita los datos de una estacion existente
        /// Valida que no existan duplicados de nombre o ubicación con otras estaciones
        /// </summary>
        /// <param name="ID">ID de la estacion a editar</param>
        /// <param name="request">Nuevos datos para actualizar la estacion</param>
        public async Task EditStation(Guid ID, EditStationDto request)
        {
            
            var station = await _context.Stations.FirstOrDefaultAsync(s => s.ID == ID);

            if (station == null)
            {
                throw new Exception("Error. Estaciono no encontrada");
            }

            var Name = request.NameStation.ToLower().Trim();
            var Location = request.Location.ToLower().Trim();

            
            var exist = await _context.Stations.FirstOrDefaultAsync(s => s.ID != ID && (s.NameStation.ToLower().Trim() == Name || s.Location.ToLower().Trim() == Location));

            if (exist != null)
            {
                if (exist.NameStation.ToLower().Trim() == Name)
                {
                    throw new Exception("Error. Ya existe una estación con este nombre");
                }
                else if (exist.Location.ToLower().Trim() == Location)
                {
                    throw new Exception("Error. Ya existe una estación con esta Ubicacion");
                }
            }

            
            station.NameStation = request.NameStation;
            station.Location = request.Location;
            station.Type = request.Type;
            
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Cambia el estado de una estacion (Activa/Inactiva)
        /// Implementa soft delete alternando el valor del campo State activando/desactivando la estacion
        /// </summary>
        /// <param name="ID">ID de la estacion</param>
        public async Task DisabledEnabledStation(Guid ID)
        {
            // Buscar estación por ID
            var Station = await _context.Stations.FirstOrDefaultAsync(s => s.ID == ID);

            if (Station == null)
            {
                throw new Exception("Error. Estacion no encontrada");
            }

            
            Station.State = !Station.State;
            _context.Update(Station);
            await _context.SaveChangesAsync();
        }
    }
}
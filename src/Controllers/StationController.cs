using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stationService.src.Interface;
using stationService.src.Model;
using stationService.src.StationDto;

namespace stationService.src.Controllers
{
    /// <summary>
    /// Controlador de Estaciones
    /// Proporciona endopoints para la creacion, visualizacion, edicion de estaciones
    /// Ademas de un cambio de estado implementado 
    /// como soft delete
    /// </summary>
    [Route("Station")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationRepository _stationRepository;

        /// <summary>
        /// Constructor del controlador de estaciones
        /// </summary>
        /// <param name="stationRepository">Repositorio para operaciones de estaciones</param>
        public StationController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        /// <summary>
        /// Crea una nueva estación en el sistema
        /// </summary>
        /// <param name="request">DTO con los datos de la estacion a crear</param>
        /// <returns>Devuelve la informacion de la nueva estacion como DTO</returns>
        [HttpPost("CreateStation")]
        public async Task<IActionResult> CreateStation(CreateStationDto request)
        {
            try
            {
            
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                
                var result = await _stationRepository.CreateStation(request);

                return Ok(new
                {
                    message = "Estacion creada con exito",
                    Station = result
                });
            }
            catch (Exception e)
            {
                
                return StatusCode(500, new { message = e.Message });
            }
        }

        /// <summary>
        /// Obtener el listado de estaciones con la posibilidad de aplicar filtros
        /// </summary>
        /// <param name="Name">Filtro opcional por nombre de estacion</param>
        /// <param name="Type">Filtro opcional por tipo de estacion</param>
        /// <param name="State">Filtro opcional por estado de la estacion (activa/inactiva)</param>
        /// <returns>Listado de estaciones que coinciden con los filtros aplicados</returns>
        [HttpGet("Stations")]
        public async Task<IActionResult> GetStations([FromQuery] string? Name, [FromQuery] string? Type, [FromQuery] bool? State)
        {
            try
            {
                
                var Stations = await _stationRepository.GetStations(Name, Type, State);

                var response = new
                {
                    message = "Lista de estaciones obtenida exitosamente",
                    Estaciones = Stations
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                
                return StatusCode(500, new { message = e.Message });
            }
        }

        /// <summary>
        /// Obtiene una estacion especifica por ID
        /// </summary>
        /// <param name="ID">ID unico de estacion </param>
        /// <returns>Datos de la estacion que coincide con la ID</returns>
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetStationByID(Guid ID)
        {
            try
            {
                
                var Station = await _stationRepository.GetStationById(ID);

                var response = new
                {
                    message = "Estacion obtenido con exito",
                    Estacion = Station
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                
                return StatusCode(500, new { message = e.Message });
            }
        }

        /// <summary>
        /// Edita los datos de una estacion existente
        /// </summary>
        /// <param name="ID">ID de estacion a editar</param>
        /// <param name="request">Datos actualizados de la estacion mediante DTO</param>
        /// <returns>Confirmación de la actualización exitosa</returns>
        [HttpPut("EditStation/{ID}")]
        public async Task<IActionResult> EditStation(Guid ID, EditStationDto request)
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            
                var modifiedStation = await _stationRepository.EditStation(ID, request);

                return Ok(new
                {

                    message = "Estacion Editada con exito",
                    Estacion = modifiedStation
                });
            }
            catch (Exception e)
            {
            
                return StatusCode(500, new { message = e.Message });
            }
        }

        /// <summary>
        /// Cambia el estado de una estación (Activa/Inactiva)
        /// Implementado como un soft delete el cual es reversible
        /// </summary>
        /// <param name="ID">ID de estacion</param>
        /// <returns>Confirmación del cambio de estado</returns>
        [HttpPut("ChangeStateStation/{ID}")]
        public async Task<IActionResult> SoftDelete(Guid ID)
        {
            try
            {
                
                await _stationRepository.DisabledEnabledStation(ID);

                return Ok(new { message = "Estado de estacion cambiado correctamente" });
            }
            catch (Exception e)
            {
                
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
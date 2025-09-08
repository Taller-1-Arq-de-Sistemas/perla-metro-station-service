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
    [Route("api/Station")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationRepository _stationRepository;


        public StationController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }


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

        [HttpGet("Stations")]
        public async Task<IActionResult> GetStations()
        {
            try
            {
                var Stations = await _stationRepository.GetStations();

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

        [HttpGet("Station")]
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

        




    }
}
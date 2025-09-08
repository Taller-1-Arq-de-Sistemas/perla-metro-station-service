using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stationService.src.Data;
using stationService.src.Interface;
using stationService.src.Mapers;
using stationService.src.Model;
using stationService.src.StationDto;

namespace stationService.src.Repository
{
    public class StationRepository : IStationRepository
    {
        //DbContext dedicado para operaciones de testing
        private readonly TestingDBContext _testingContext;

        public StationRepository(TestingDBContext testingContext)
        {
            _testingContext = testingContext;
        }

        //Crear Estacion
        public async Task<ResponseStationDto> CreateStation(CreateStationDto request)
        {
            var StationRequest = new Station
            {

                // ID UIDD V4 se crea en el modelo
                NameStation = request.NameStation,
                Location = request.Location,
                Type = request.Type,
                State = true

            };


            // Crear en la base de datos de prueba y guardar cambios
            await _testingContext.Stations.AddAsync(StationRequest);
            await _testingContext.SaveChangesAsync();

            //Response
            var response = StationRequest.ToStationResponse();
            return response;
        }


        //Get de estaciones
        public async Task<List<ResponseStationDto>> GetStations()
        {

            //Buscar en la base de datos de prueba
            var Stations = await _testingContext.Stations.Select(s => s.ToStationResponse()).ToListAsync();

            if (Stations.Count == 0)
            {
                throw new Exception("Error. No se encontraron Estaciones");
            }

            return Stations;
        }



        //Get by Id de estaciones
        public async Task<ResponseStationDto> GetStationById(Guid ID)
        {
            //Buscar en la base de datos de prueba
            var Station = await _testingContext.Stations.FirstOrDefaultAsync(s => s.ID == ID && s.State == true);

            if (Station == null)
            {
                throw new Exception("Error. Estacion no encontrada");
            }

            var response = Station.ToStationResponse();

            return response;

        }




        //Edicion de estaciones
        //TODO



        //SoftDelete (Desactivar/Activar), solo administradores
        public async Task DisabledEnabledStation(Guid ID)
        {
            var Station = await _testingContext.Stations.FirstOrDefaultAsync(s => s.ID == ID);

            if (Station == null)
            {
                throw new Exception("Error. Estacion no encontrada");
            }

            //Actualizar en base de datos de prueba
            Station.State = !Station.State;
            _testingContext.Update(Station);
            await _testingContext.SaveChangesAsync();
        }



    }
}
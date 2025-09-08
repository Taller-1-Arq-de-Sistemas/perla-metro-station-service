using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        //TODO
        public async Task<ResponseStationDto> CreateStation(CreateStationDto request)
        {
            var StationRequest = new Station
            {

                // ID UIDD V4 se crea en el modelo
                NameStation = request.NameStation,
                Location = request.Location,
                Type = request.Type,
                IsActive = true

            };


            // Crear en la base de datos de prueba y guardar cambios
            await _testingContext.Stations.AddAsync(StationRequest);
            await _testingContext.SaveChangesAsync();

            //Response
            var response = StationRequest.ToStationResponse();
            return response;
        }
        
    }
}
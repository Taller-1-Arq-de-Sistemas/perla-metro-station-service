using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using stationService.src.Data;
using stationService.src.Interface;
using stationService.src.Model;

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
        //public async Task<Station> CreateStation(int Id, string Name, string location, string Type, bool isActive)
        
    }
}
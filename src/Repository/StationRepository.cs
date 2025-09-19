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
        private readonly DBContext _context;

        public StationRepository(DBContext context)
        {
            _context = context;
        }

        //Crear Estacion
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

                // ID UIDD V4 se crea en el modelo
                NameStation = request.NameStation,
                Location = request.Location,
                Type = request.Type,
                State = true

            };


            // guardar cambios
            await _context.Stations.AddAsync(StationRequest);
            await _context.SaveChangesAsync();

            //Response
            var response = StationRequest.ToStationResponse();
            return response;
        }


        //Get de estaciones
        public async Task<List<ResponseStationDto>> GetStations()
        {

            var Stations = await _context.Stations.Select(s => s.ToStationResponse()).ToListAsync();

            if (Stations.Count == 0)
            {
                throw new Exception("Error. No se encontraron Estaciones");
            }

            return Stations;
        }



        //Get by Id de estaciones
        public async Task<ResponseStationDto> GetStationById(Guid ID)
        {

            var Station = await _context.Stations.FirstOrDefaultAsync(s => s.ID == ID && s.State == true);

            if (Station == null)
            {
                throw new Exception("Error. Estacion no encontrada");
            }

            var response = Station.ToStationResponse();

            return response;

        }




        //Edicion de estaciones
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


            //actualizar atributos
            station.NameStation = request.NameStation;
            station.Location = request.Location;
            station.Type = request.Type;
            
            await _context.SaveChangesAsync();
        }


        //SoftDelete (Desactivar/Activar), solo administradores
        public async Task DisabledEnabledStation(Guid ID)
        {
            var Station = await _context.Stations.FirstOrDefaultAsync(s => s.ID == ID);

            if (Station == null)
            {
                throw new Exception("Error. Estacion no encontrada");
            }

            //Actualizar en base de datos de prueba
            Station.State = !Station.State;
            _context.Update(Station);
            await _context.SaveChangesAsync();
        }



    }
}
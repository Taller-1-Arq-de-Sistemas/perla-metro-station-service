using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationService.src.Model;

namespace stationService.src.Helper
{
    /// <summary>
    /// Clase helper para aplicar filtros a listado de estaciones
    /// Proporciona metodos estaticos para filtrar estaciones mediante nombre, tipo o estado
    /// </summary>
    public class StationFilterHelper
    {
        /// <summary>
        /// Aplica filtros opcionales a una consulta IQueryable de estaciones
        /// Los filtros se aplican de manera condicional solo si los parametros tienen valores
        /// </summary>
        /// <param name="query">Consulta base de estaciones a filtrar</param>
        /// <param name="Name">Filtro opcional por nombre de estacian (insensible a maysculas)</param>
        /// <param name="Type">Filtro opcional por tipo de estación (insensible a mayusculas)</param>
        /// <param name="State">Filtro opcional por estado de la estación (true = activa, false = inactiva)</param>
        /// <returns>Consulta IQueryable con los filtros aplicados</returns>
        public static IQueryable<Station> Filters(IQueryable<Station> query, string? Name, string? Type, bool? State)
        {
            
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(s => s.NameStation.ToLower().Contains(Name.ToLower().Trim()));
            }

           
            if (!string.IsNullOrEmpty(Type))
            {
                query = query.Where(s => s.Type.ToLower().Contains(Type.ToLower().Trim()));
            }

           
            if (State != null)
            {
                query = query.Where(s => s.State == State);
            }

            return query;
        }
    }
}
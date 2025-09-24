using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stationService.src.StationDto
{
    /// <summary>
    /// DTO de respuesta para las operaciones
    /// Contiene toda la información de una estación para ser devuelta al cliente
    /// </summary>
    public class ResponseStationDto
    {
        /// <summary>
        /// Identificador unico UUID V4
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Nombre de la estacion
        /// </summary>
        public string NameStation { get; set; } = string.Empty;

        /// <summary>
        /// Ubicacion de estacion
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de estacion 
        /// Valores posibles: Origen, Destino, Intermedia
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Estado actual de la estación
        /// True = Activa, False = Inactiva
        /// </summary>
        public bool State { get; set; }
    }
}
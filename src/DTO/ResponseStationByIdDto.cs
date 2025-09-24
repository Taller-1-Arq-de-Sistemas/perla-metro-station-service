using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stationService.src.DTO
{
    /// <summary>
    /// DTO de respuesta para la operacion " Get by Id"
    /// Contiene toda la información de una estacion expeto su estado para ser devuelta al cliente
    /// </summary>
    public class ResponseStationByIdDto
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

    }
}
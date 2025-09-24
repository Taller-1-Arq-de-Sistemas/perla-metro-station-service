using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stationService.src.StationDto
{
    /// <summary>
    /// DTO para la edicion de una estación existente
    /// Contiene los campos modificables de una estacion
    /// </summary>
    public class EditStationDto
    {
        /// <summary>
        /// Nombre de la estación
        /// </summary>
        public string NameStation { get; set; } = string.Empty;

        /// <summary>
        /// Ubicacion de la estacion
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de estacion
        /// Valores permitidos: Origen, Destino, Intermedia
        /// </summary>
        [RegularExpression("Origen|Destino|Intermedia", ErrorMessage = "El tipo debe ser Origen, Destino o Intermedia")]
        public string Type { get; set; } = string.Empty;
}
}
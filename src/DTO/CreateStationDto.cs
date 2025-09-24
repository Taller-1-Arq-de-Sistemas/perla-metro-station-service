using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stationService.src.StationDto
{
    /// <summary>
    /// DTO para la creacion de una nueva estacion
    /// Contiene los datos necesarios para crear una estación en el sistema
    /// </summary>
    public class CreateStationDto
    {
        /// <summary>
        /// Nombre de la estación a crear (obligatorio)
        /// </summary>
        [Required(ErrorMessage = "El nombre de la estacion es requerido")]
        public string NameStation { get; set; } = string.Empty;

        /// <summary>
        /// Ubicacion de la estacion a crear (obligatorio)
        /// </summary>
        [Required(ErrorMessage = "La ubicacion de la estacion es requerido")]
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de estacion a crear (obligatorio)
        /// Valores permitidos: Origen, Destino, Intermedia
        /// </summary>
        [Required(ErrorMessage = "El tipo de la estacion es requerido")]
        [RegularExpression("Origen|Destino|Intermedia", ErrorMessage = "El tipo debe ser Origen, Destino o Intermedia")]
        public string Type { get; set; } = string.Empty;
    }
}
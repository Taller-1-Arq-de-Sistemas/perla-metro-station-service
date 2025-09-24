using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stationService.src.Model
{
    /// <summary>
    /// Entidad que representa una estacion en el sistema
    /// Modelo de datos para la tabla de estaciones en la base de datos
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Identificador unico UUID V4
        /// Se genera automaticamente un nuevo GUID al crear la instancia
        /// </summary>
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Nombre de la estacion
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

        /// <summary>
        /// Estado actual de la estacion
        /// True = Activa, False = Inactiva
        /// </summary>
        public bool State { get; set; }
    }
}
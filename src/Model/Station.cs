using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stationService.src.Model
{
    public class Station
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        public string NameStation { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        [RegularExpression("Origen|Destino|Intermedia", ErrorMessage = "El tipo debe ser Origen, Destino o Intermedia")]
        public string Type { get; set; } = string.Empty;

        public bool IsActive { get; set; } 
    }
}
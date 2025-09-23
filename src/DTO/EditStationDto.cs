using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stationService.src.StationDto
{
    public class EditStationDto
    {
        public string NameStation { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        [RegularExpression("Origen|Destino|Intermedia", ErrorMessage = "El tipo debe ser Origen, Destino o Intermedia")]
        public string Type { get; set; } = string.Empty;
    }
}
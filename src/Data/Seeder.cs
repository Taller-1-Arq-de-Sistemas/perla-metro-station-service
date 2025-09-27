using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationService.src.Model;


namespace stationService.src.Data
{
    /// <summary>
    /// Clase responsable de inicializar datos por defecto en la base de datos.
    /// </summary>
    public class Seeder
    {

        /// <summary>
        /// Inserta datos iniciales en la base de datos si no existen registros previos en la tabla <c>Stations</c>.
        /// </summary>
        /// <param name="context">Instancia del contexto de base de datos <see cref="DBContext"/>.</param>
        public static async Task SeedData(DBContext context)
        {

            if (!context.Stations.Any())
            {

                var stations = new List<Station>
                {

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion La Chimba",
                        Location = "Av. Pedro Aguirre Cerda 11679",
                        Type = "Origen",
                        State = true
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion Terminal de Buses",
                        Location = "AV. Pedro Aguirre Cerda 253",
                        Type = "Origen",
                        State = true
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion Paseo La Portada",
                        Location = "Avenida Pedro Aguirre Cerda 10578",
                        Type = "Origen",
                        State = false
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion Inacap",
                        Location = "Av. Edmundo Pérez Zujovic 11092",
                        Type = "Origen",
                        State = true
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion Plaza Colon",
                        Location = "Arturo Prat 316",
                        Type = "Intermedia",
                        State = true
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion Municipal",
                        Location = "Av. Séptimo de Línea 3505",
                        Type = "Intermedia",
                        State = false
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion Mall Plaza",
                        Location = "Av. Balmaceda 2355",
                        Type = "Intermedia",
                        State = true
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion Balneario Municipal",
                        Location = "Av. República de Croacia 115",
                        Type = "Intermedia",
                        State = true
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion UCN",
                        Location = "Av. Angamos 0610",
                        Type = "Destino",
                        State = true

                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion Mall Parque Angamos",
                        Location = "Av. Angamos 0610",
                        Type = "Destino",
                        State = true
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion UA",
                        Location = "Av. Angamos 061",
                        Type = "Destino",
                        State = true
                    },

                    new Station
                    {
                        ID = Guid.NewGuid(),
                        NameStation ="Estacion Coloso",
                        Location = "Ruta 1",
                        Type = "Destino",
                        State = false
                    },


                };

                await context.AddRangeAsync(stations);
                await context.SaveChangesAsync();

            }


        }
    }
}
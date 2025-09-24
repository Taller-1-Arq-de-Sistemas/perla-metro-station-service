using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stationService.src.Model;

namespace stationService.src.Data
{
    /// <summary>
    /// Contexto de base de dato para servicio
    /// Proporciona acceso a las entidades y maneja las operaciones de base de datos
    /// </summary>
    public class DBContext : DbContext
    {
        /// <summary>
        /// Constructor del contexto de base de datos
        /// </summary>
        /// <param name="options">Opciones de configuracion para el contexto de base de datos</param>
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        /// <summary>
        /// Entidad Station (Estacion) para operaciones CRUD en la tabla Stations (Estaciones)
        /// </summary>
        public DbSet<Station> Stations { get; set; } = null!;
    }
}
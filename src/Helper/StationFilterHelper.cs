using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationService.src.Model;

namespace stationService.src.Helper
{
    public class StationFilterHelper
    {
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
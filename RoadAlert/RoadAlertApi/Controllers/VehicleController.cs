using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoadAlertApi.Models;
using RoadAlertApi.Models.Vehicles;

namespace RoadAlertApi.Controllers
{
    public class VehicleController:Controller
    {
        private VehicleAlertsContext _dbContext;

        public VehicleController(VehicleAlertsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyList<StoppedVehicle> Stopped()
        {
            var expr = from tpms in _dbContext.Tpms
                from gps in _dbContext.GnssPositions
                where tpms.AlertId == gps.AlertId
                      && tpms.PressureActual < 140
                      && gps.Speed < 10
                select new StoppedVehicle()
                {
                    Lat = gps.Latitude.Value, Lon = gps.Longitude.Value, Heading = gps.Heading.Value,
                    RegisteredAt = gps.PositionDateTime.Value
                };


            return expr.ToList();
            //_dbContext.Tpms.Where(x=>x.PressureActual < 140)
            //    .Join(x=>x.)
        }
    }
}

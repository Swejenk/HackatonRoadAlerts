using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoadAlertApi.Models;
using RoadAlertApi.Models.Vehicles;
using RoadAlertApi.Tools;

namespace RoadAlertApi.Controllers
{
    [ApiController]
    [Route("vehicles")]
    public class VehicleController:Controller
    {
        private VehicleAlertsContext _dbContext;

        public VehicleController(VehicleAlertsContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("stopped")]
        [Produces("application/json", "application/geo+json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesContentSchema(typeof(IEnumerable<StoppedVehicle>), StatusCodes.Status200OK, "application/json")]
        [ProducesContentSchema(typeof(GeoJSON.Net.Feature.FeatureCollection), StatusCodes.Status200OK, "application/geo+json")]
        public IActionResult Stopped()
        {
            var stoppedVehicles = 
                from tpms in _dbContext.Tpms
                from gps in _dbContext.GnssPositions
                where tpms.AlertId == gps.AlertId
                      && tpms.PressureActual < 140
                      && gps.Speed < 10
                select new StoppedVehicle()
                {
                    Lat = gps.Latitude.Value, Lon = gps.Longitude.Value, Heading = gps.Heading.Value,
                    RegisteredAt = gps.PositionDateTime.Value,Vin = gps.Alert.Vin
                };

            if (Request.ContentType == "application/geo+json")
            {
                return Json(stoppedVehicles.ToGeoJsonFeatureCollection());
            }

            return Ok(stoppedVehicles.ToList());
        }
    }
}

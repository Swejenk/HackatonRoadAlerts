using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using RoadAlertApi.Models.Vehicles;

namespace RoadAlertApi.Tools;

public static class GeoJsonConverterExtensions
{
    public static Feature ToGeoJsonFeature(this StoppedVehicle vehicle)
    {
        var point = new Point(new Position(vehicle.Lat, vehicle.Lon));

        var properties = new Dictionary<string, object>
        {
            ["vin"] = vehicle.Vin,
            ["registeredAt"] = vehicle.RegisteredAt,
            ["heading"] = vehicle.Heading
        };

        return new Feature(point, properties);
    }

    public static FeatureCollection ToGeoJsonFeatureCollection(this IEnumerable<StoppedVehicle> vehicles)
    {
        var features = vehicles.Select(v => v.ToGeoJsonFeature()).ToList();
        return new FeatureCollection(features);
    }
}
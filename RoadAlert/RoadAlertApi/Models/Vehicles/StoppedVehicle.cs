namespace RoadAlertApi.Models.Vehicles;

public class StoppedVehicle
{
    public double Lat { get; init; }
    public double Lon { get; set; }
    public DateTime RegisteredAt { get; set; }

    public int Heading { get; set; }
}
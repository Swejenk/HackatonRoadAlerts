using System;
using System.Collections.Generic;

namespace RoadAlertApi.Models;

public partial class Tpm
{
    public int? AlertId { get; set; }

    public string? Source { get; set; }

    public int? AxleId { get; set; }

    public string? TireLocation { get; set; }

    public bool? TpmActive { get; set; }

    public string? BatteryStatus { get; set; }

    public string? EventType { get; set; }

    public bool? InformationEvent { get; set; }

    public string? LeakageWarning { get; set; }

    public double? Temperature { get; set; }

    public string? TemperatureStatus { get; set; }

    public double? PressureActual { get; set; }

    public double? PressureReference { get; set; }

    public string? PressureWarning { get; set; }

    public virtual Alert? Alert { get; set; }
}

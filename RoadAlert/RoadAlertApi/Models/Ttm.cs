using System;
using System.Collections.Generic;

namespace RoadAlertApi.Models;

public partial class Ttm
{
    public int? AlertId { get; set; }

    public string? Source { get; set; }

    public int? AxleId { get; set; }

    public string? TireLocation { get; set; }

    public bool? TireActive { get; set; }

    public string? BatteryStatus { get; set; }

    public string? EventType { get; set; }

    public bool? InformationEvent { get; set; }

    public double? TemperatureActual { get; set; }

    public string? TemperatureWarning { get; set; }

    public virtual Alert? Alert { get; set; }
}

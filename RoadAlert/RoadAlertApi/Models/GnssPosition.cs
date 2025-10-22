using System;
using System.Collections.Generic;

namespace RoadAlertApi.Models;

public partial class GnssPosition
{
    public int? AlertId { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public int? Heading { get; set; }

    public double? Altitude { get; set; }

    public double? Speed { get; set; }

    public DateTime? PositionDateTime { get; set; }

    public virtual Alert? Alert { get; set; }
}

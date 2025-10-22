using System;
using System.Collections.Generic;

namespace RoadAlertApi.Models;

public partial class Cargo
{
    public int? AlertId { get; set; }

    public bool? CargoDefrostOn { get; set; }

    public bool? CargoDoorOpen { get; set; }

    public string? CargoTemperatures { get; set; }

    public virtual Alert? Alert { get; set; }
}

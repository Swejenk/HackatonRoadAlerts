using System;
using System.Collections.Generic;

namespace RoadAlertApi.Models;

public partial class DriverId
{
    public int? AlertId { get; set; }

    public long? TachoDriverIdentification { get; set; }

    public string? CardIssuingMemberState { get; set; }

    public string? DriverAuthenticationEquipment { get; set; }

    public int? CardReplacementIndex { get; set; }

    public int? CardRenewalIndex { get; set; }

    public string? OemDriverIdentificationIdType { get; set; }

    public string? OemDriverIdentification { get; set; }

    public virtual Alert? Alert { get; set; }
}

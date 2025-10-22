using System;
using System.Collections.Generic;

namespace RoadAlertApi.Models;

public partial class Alert
{
    public int Id { get; set; }

    public string? AlertType { get; set; }

    public string? Severity { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? ReceivedDateTime { get; set; }

    public string? Vin { get; set; }

    public string? CustomerVehicleName { get; set; }

    public long? HrTotalVehicleDistance { get; set; }

    public double? TotalEngineHours { get; set; }

    public double? TotalElectricMotorHours { get; set; }

    public string? GenericTriggerType { get; set; }

    public string? TachoOutOfModeEventType { get; set; }

    public string? GeofenceName { get; set; }

    public string? GeofenceMessage { get; set; }

    public string? GeofenceEventType { get; set; }

    public string? SafetyZoneName { get; set; }

    public string? SafetyZoneEventType { get; set; }

    public int? SafetyZoneTopSpeed { get; set; }

    public string? SafetyZoneOverspeedingReason { get; set; }

    public int? SafetyZoneDuration { get; set; }

    public string? OverspeedTriggerType { get; set; }

    public string? OverspeedEventType { get; set; }

    public double? OverspeedWheelBasedSpeed { get; set; }

    public double? OverspeedLimit { get; set; }

    public string? IdlingEventType { get; set; }

    public int? IdlingAmbientAirTemperature { get; set; }

    public string? IdlingAirProductionModulatorState { get; set; }

    public int? IdlingCoolantTemperature { get; set; }

    public string? IdlingRegenerationFilterState { get; set; }

    public int? FuelLevelFuelLevel1 { get; set; }

    public int? FuelLevelFuelLevel1ChangePercent { get; set; }

    public int? CatalystFuelLevel { get; set; }

    public int? CatalystFuelLevelChangePercent { get; set; }

    public string? PtoId { get; set; }

    public string? PtoEventType { get; set; }

    public int? PtoBatteryLevel { get; set; }

    public int? PtoAmbientAirTemperature { get; set; }

    public string? PtoAirProductionModulatorState { get; set; }

    public int? PtoCoolantTemperature { get; set; }

    public string? PtoRegenerationFilterState { get; set; }

    public string? ChargingStatusInfoEvent { get; set; }

    public long? ChargingStatusInfoEstimatedDistanceToEmptyTotal { get; set; }

    public long? ChargingStatusInfoEstimatedDistanceToEmptyFuel { get; set; }

    public long? ChargingStatusInfoEstimatedDistanceToEmptyGas { get; set; }

    public long? ChargingStatusInfoEstimatedDistanceToEmptyBatteryPack { get; set; }

    public int? ChargingStatusInfoHybridBatteryPackRemainingCharge { get; set; }

    public DateTime? ChargingStatusInfoEstimatedTimeBatteryPackChargingCompleted { get; set; }

    public string? ChargingConnectionStatusInfoEvent { get; set; }

    public string? ChargingConnectionStatusInfoEventDetail { get; set; }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoadAlertApi.Migrations
{
    /// <inheritdoc />
    public partial class Added_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReceivedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Vin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerVehicleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HrTotalVehicleDistance = table.Column<long>(type: "bigint", nullable: true),
                    TotalEngineHours = table.Column<double>(type: "float", nullable: true),
                    TotalElectricMotorHours = table.Column<double>(type: "float", nullable: true),
                    GenericTriggerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TachoOutOfModeEventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GeofenceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GeofenceMessage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeofenceEventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SafetyZoneName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SafetyZoneEventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SafetyZoneTopSpeed = table.Column<int>(type: "int", nullable: true),
                    SafetyZoneOverspeedingReason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SafetyZoneDuration = table.Column<int>(type: "int", nullable: true),
                    OverspeedTriggerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OverspeedEventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OverspeedWheelBasedSpeed = table.Column<double>(type: "float", nullable: true),
                    OverspeedLimit = table.Column<double>(type: "float", nullable: true),
                    IdlingEventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdlingAmbientAirTemperature = table.Column<int>(type: "int", nullable: true),
                    IdlingAirProductionModulatorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdlingCoolantTemperature = table.Column<int>(type: "int", nullable: true),
                    IdlingRegenerationFilterState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FuelLevelFuelLevel1 = table.Column<int>(type: "int", nullable: true),
                    FuelLevelFuelLevel1ChangePercent = table.Column<int>(type: "int", nullable: true),
                    CatalystFuelLevel = table.Column<int>(type: "int", nullable: true),
                    CatalystFuelLevelChangePercent = table.Column<int>(type: "int", nullable: true),
                    PtoId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PtoEventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PtoBatteryLevel = table.Column<int>(type: "int", nullable: true),
                    PtoAmbientAirTemperature = table.Column<int>(type: "int", nullable: true),
                    PtoAirProductionModulatorState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PtoCoolantTemperature = table.Column<int>(type: "int", nullable: true),
                    PtoRegenerationFilterState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChargingStatusInfoEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChargingStatusInfoEstimatedDistanceToEmptyTotal = table.Column<long>(type: "bigint", nullable: true),
                    ChargingStatusInfoEstimatedDistanceToEmptyFuel = table.Column<long>(type: "bigint", nullable: true),
                    ChargingStatusInfoEstimatedDistanceToEmptyGas = table.Column<long>(type: "bigint", nullable: true),
                    ChargingStatusInfoEstimatedDistanceToEmptyBatteryPack = table.Column<long>(type: "bigint", nullable: true),
                    ChargingStatusInfoHybridBatteryPackRemainingCharge = table.Column<int>(type: "int", nullable: true),
                    ChargingStatusInfoEstimatedTimeBatteryPackChargingCompleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChargingConnectionStatusInfoEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChargingConnectionStatusInfoEventDetail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Alerts__3214EC07CD84463D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    AlertId = table.Column<int>(type: "int", nullable: true),
                    CargoDefrostOn = table.Column<bool>(type: "bit", nullable: true),
                    CargoDoorOpen = table.Column<bool>(type: "bit", nullable: true),
                    CargoTemperatures = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Cargo__AlertId__3C69FB99",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DriverId",
                columns: table => new
                {
                    AlertId = table.Column<int>(type: "int", nullable: true),
                    TachoDriverIdentification = table.Column<long>(type: "bigint", nullable: true),
                    CardIssuingMemberState = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DriverAuthenticationEquipment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CardReplacementIndex = table.Column<int>(type: "int", nullable: true),
                    CardRenewalIndex = table.Column<int>(type: "int", nullable: true),
                    OemDriverIdentificationIdType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OemDriverIdentification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__DriverId__AlertI__38996AB5",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GnssPosition",
                columns: table => new
                {
                    AlertId = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Heading = table.Column<int>(type: "int", nullable: true),
                    Altitude = table.Column<double>(type: "float", nullable: true),
                    Speed = table.Column<double>(type: "float", nullable: true),
                    PositionDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__GnssPosit__Alert__3A81B327",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tpm",
                columns: table => new
                {
                    AlertId = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AxleId = table.Column<int>(type: "int", nullable: true),
                    TireLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TpmActive = table.Column<bool>(type: "bit", nullable: true),
                    BatteryStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InformationEvent = table.Column<bool>(type: "bit", nullable: true),
                    LeakageWarning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: true),
                    TemperatureStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PressureActual = table.Column<double>(type: "float", nullable: true),
                    PressureReference = table.Column<double>(type: "float", nullable: true),
                    PressureWarning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Tpm__AlertId__3E52440B",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ttm",
                columns: table => new
                {
                    AlertId = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AxleId = table.Column<int>(type: "int", nullable: true),
                    TireLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TireActive = table.Column<bool>(type: "bit", nullable: true),
                    BatteryStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InformationEvent = table.Column<bool>(type: "bit", nullable: true),
                    TemperatureActual = table.Column<double>(type: "float", nullable: true),
                    TemperatureWarning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Test = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Ttm__AlertId__403A8C7D",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_AlertId",
                table: "Cargo",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverId_AlertId",
                table: "DriverId",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_GnssPosition_AlertId",
                table: "GnssPosition",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Tpm_AlertId",
                table: "Tpm",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Ttm_AlertId",
                table: "Ttm",
                column: "AlertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "DriverId");

            migrationBuilder.DropTable(
                name: "GnssPosition");

            migrationBuilder.DropTable(
                name: "Tpm");

            migrationBuilder.DropTable(
                name: "Ttm");

            migrationBuilder.DropTable(
                name: "Alerts");
        }
    }
}

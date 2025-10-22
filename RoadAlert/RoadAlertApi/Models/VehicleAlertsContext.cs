using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoadAlertApi.Models;

public partial class VehicleAlertsContext : DbContext
{
    public VehicleAlertsContext()
    {
    }

    public VehicleAlertsContext(DbContextOptions<VehicleAlertsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<DriverId> DriverIds { get; set; }

    public virtual DbSet<GnssPosition> GnssPositions { get; set; }

    public virtual DbSet<Tpm> Tpms { get; set; }

    public virtual DbSet<Ttm> Ttms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=VehicleAlerts;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alerts__3214EC07CD84463D");

            entity.Property(e => e.AlertType).HasMaxLength(50);
            entity.Property(e => e.ChargingConnectionStatusInfoEvent).HasMaxLength(50);
            entity.Property(e => e.ChargingConnectionStatusInfoEventDetail).HasMaxLength(255);
            entity.Property(e => e.ChargingStatusInfoEstimatedTimeBatteryPackChargingCompleted).HasColumnType("datetime");
            entity.Property(e => e.ChargingStatusInfoEvent).HasMaxLength(50);
            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.CustomerVehicleName).HasMaxLength(100);
            entity.Property(e => e.GenericTriggerType).HasMaxLength(50);
            entity.Property(e => e.GeofenceEventType).HasMaxLength(50);
            entity.Property(e => e.GeofenceMessage).HasMaxLength(255);
            entity.Property(e => e.GeofenceName).HasMaxLength(100);
            entity.Property(e => e.IdlingAirProductionModulatorState).HasMaxLength(50);
            entity.Property(e => e.IdlingEventType).HasMaxLength(50);
            entity.Property(e => e.IdlingRegenerationFilterState).HasMaxLength(50);
            entity.Property(e => e.OverspeedEventType).HasMaxLength(50);
            entity.Property(e => e.OverspeedTriggerType).HasMaxLength(50);
            entity.Property(e => e.PtoAirProductionModulatorState).HasMaxLength(50);
            entity.Property(e => e.PtoEventType).HasMaxLength(50);
            entity.Property(e => e.PtoId).HasMaxLength(50);
            entity.Property(e => e.PtoRegenerationFilterState).HasMaxLength(50);
            entity.Property(e => e.ReceivedDateTime).HasColumnType("datetime");
            entity.Property(e => e.SafetyZoneEventType).HasMaxLength(50);
            entity.Property(e => e.SafetyZoneName).HasMaxLength(100);
            entity.Property(e => e.SafetyZoneOverspeedingReason).HasMaxLength(100);
            entity.Property(e => e.Severity).HasMaxLength(50);
            entity.Property(e => e.TachoOutOfModeEventType).HasMaxLength(50);
            entity.Property(e => e.Vin).HasMaxLength(50);
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cargo");

            entity.HasOne(d => d.Alert).WithMany()
                .HasForeignKey(d => d.AlertId)
                .HasConstraintName("FK__Cargo__AlertId__3C69FB99");
        });

        modelBuilder.Entity<DriverId>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DriverId");

            entity.Property(e => e.CardIssuingMemberState).HasMaxLength(5);
            entity.Property(e => e.DriverAuthenticationEquipment).HasMaxLength(50);
            entity.Property(e => e.OemDriverIdentification).HasMaxLength(50);
            entity.Property(e => e.OemDriverIdentificationIdType).HasMaxLength(50);

            entity.HasOne(d => d.Alert).WithMany()
                .HasForeignKey(d => d.AlertId)
                .HasConstraintName("FK__DriverId__AlertI__38996AB5");
        });

        modelBuilder.Entity<GnssPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GnssPosition");

            entity.Property(e => e.PositionDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Alert).WithMany()
                .HasForeignKey(d => d.AlertId)
                .HasConstraintName("FK__GnssPosit__Alert__3A81B327");
        });

        modelBuilder.Entity<Tpm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tpm");

            entity.Property(e => e.BatteryStatus).HasMaxLength(50);
            entity.Property(e => e.EventType).HasMaxLength(50);
            entity.Property(e => e.LeakageWarning).HasMaxLength(50);
            entity.Property(e => e.PressureWarning).HasMaxLength(50);
            entity.Property(e => e.Source).HasMaxLength(50);
            entity.Property(e => e.TemperatureStatus).HasMaxLength(50);
            entity.Property(e => e.TireLocation).HasMaxLength(50);

            entity.HasOne(d => d.Alert).WithMany()
                .HasForeignKey(d => d.AlertId)
                .HasConstraintName("FK__Tpm__AlertId__3E52440B");
        });

        modelBuilder.Entity<Ttm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Ttm");

            entity.Property(e => e.BatteryStatus).HasMaxLength(50);
            entity.Property(e => e.EventType).HasMaxLength(50);
            entity.Property(e => e.Source).HasMaxLength(50);
            entity.Property(e => e.TemperatureWarning).HasMaxLength(50);
            entity.Property(e => e.TireLocation).HasMaxLength(50);

            entity.HasOne(d => d.Alert).WithMany()
                .HasForeignKey(d => d.AlertId)
                .HasConstraintName("FK__Ttm__AlertId__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClinicWPF.Models;

public partial class ClinicSystemContext : DbContext
{
    public ClinicSystemContext()
    {
    }

    public ClinicSystemContext(DbContextOptions<ClinicSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<MedicalDiagnosis> MedicalDiagnoses { get; set; }

    public virtual DbSet<MedicalProcedure> MedicalProcedures { get; set; }

    public virtual DbSet<MedicalTest> MedicalTests { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-09RAVQF;DataBase = ClinicSystem; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.PatiendId).HasColumnName("patiend_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Appointment_Doctor");

            entity.HasOne(d => d.Patiend).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatiendId)
                .HasConstraintName("FK_Appointment_Patient");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Specialization).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<MedicalDiagnosis>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Mkb)
                .HasMaxLength(50)
                .HasColumnName("mkb");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MedicalProcedure>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MedicalTest>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.ToTable("Medication");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Dose)
                .HasMaxLength(50)
                .HasColumnName("dose");
            entity.Property(e => e.Instruction)
                .HasMaxLength(50)
                .HasColumnName("instruction");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anamnesis).HasColumnName("anamnesis");
            entity.Property(e => e.DateEnd)
                .HasColumnType("date")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("date")
                .HasColumnName("date_start");
            entity.Property(e => e.Note).HasColumnName("note");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Personal");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PatiendId).HasColumnName("patiend_id");
            entity.Property(e => e.Patronimic)
                .HasMaxLength(50)
                .HasColumnName("patronimic");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.Patiend).WithMany()
                .HasForeignKey(d => d.PatiendId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personal_Patient");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.ToTable("Prescription");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateEnd)
                .HasColumnType("date")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("date")
                .HasColumnName("date_start");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.MedicationId).HasColumnName("medication_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Prescription_Doctor");

            entity.HasOne(d => d.Medication).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.MedicationId)
                .HasConstraintName("FK_Prescription_Medication");

            entity.HasOne(d => d.Patient).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Prescription_Patient");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Result)
                .HasMaxLength(50)
                .HasColumnName("result");
            entity.Property(e => e.TestId).HasColumnName("test_id");

            entity.HasOne(d => d.Patient).WithMany(p => p.TestResults)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_TestResults_Patient");

            entity.HasOne(d => d.Test).WithMany(p => p.TestResults)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("FK_TestResults_MedicalTests");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

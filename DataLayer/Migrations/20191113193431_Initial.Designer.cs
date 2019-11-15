﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191113193431_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("DataLayer.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataLayer.Entities.AssemblyUnits.ShutterReverse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CaseShutterId");

                    b.Property<string>("Drawing");

                    b.Property<int?>("FirstBronzeSleeveShutterId");

                    b.Property<int?>("FirstSteelSleeveShutterId");

                    b.Property<int?>("FirstStubShutterId");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<int?>("PIDId");

                    b.Property<int?>("SecondBronzeSleeveShutterId");

                    b.Property<int?>("SecondSteelSleeveShutterId");

                    b.Property<int?>("SecondStubShutterId");

                    b.Property<int?>("ShaftShutterId");

                    b.Property<int?>("SlamShutterId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CaseShutterId");

                    b.HasIndex("FirstBronzeSleeveShutterId");

                    b.HasIndex("FirstSteelSleeveShutterId");

                    b.HasIndex("FirstStubShutterId");

                    b.HasIndex("PIDId");

                    b.HasIndex("SecondBronzeSleeveShutterId");

                    b.HasIndex("SecondSteelSleeveShutterId");

                    b.HasIndex("SecondStubShutterId");

                    b.HasIndex("ShaftShutterId");

                    b.HasIndex("SlamShutterId");

                    b.ToTable("ShutterReverses");
                });

            modelBuilder.Entity("DataLayer.Entities.Detailing.BronzeSleeveShutter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Certificate");

                    b.Property<string>("Drawing");

                    b.Property<string>("Material");

                    b.Property<string>("Melt");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("BronzeSleeveShutters");
                });

            modelBuilder.Entity("DataLayer.Entities.Detailing.CaseShutter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Certificate");

                    b.Property<string>("Drawing");

                    b.Property<int?>("FirstNozzleId");

                    b.Property<string>("Material");

                    b.Property<string>("Melt");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<int?>("SecondNozzleId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("FirstNozzleId");

                    b.HasIndex("SecondNozzleId");

                    b.ToTable("CaseShutters");
                });

            modelBuilder.Entity("DataLayer.Entities.Detailing.Nozzle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Certificate");

                    b.Property<string>("Diameter");

                    b.Property<string>("Drawing");

                    b.Property<string>("Material");

                    b.Property<string>("Melt");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("Status");

                    b.Property<string>("Thickness");

                    b.Property<string>("ThicknessJoin");

                    b.HasKey("Id");

                    b.ToTable("Nozzles");
                });

            modelBuilder.Entity("DataLayer.Entities.Detailing.ShaftShutter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Certificate");

                    b.Property<string>("Drawing");

                    b.Property<string>("Material");

                    b.Property<string>("Melt");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("ShaftShutters");
                });

            modelBuilder.Entity("DataLayer.Entities.Detailing.SlamShutter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Certificate");

                    b.Property<string>("Drawing");

                    b.Property<string>("Material");

                    b.Property<string>("Melt");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("SlamShutters");
                });

            modelBuilder.Entity("DataLayer.Entities.Detailing.SteelSleeveShutter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Certificate");

                    b.Property<string>("Drawing");

                    b.Property<string>("Material");

                    b.Property<string>("Melt");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("SteelSleeveShutters");
                });

            modelBuilder.Entity("DataLayer.Entities.Detailing.StubShutter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Certificate");

                    b.Property<string>("Drawing");

                    b.Property<string>("Material");

                    b.Property<string>("Melt");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("StubShutters");
                });

            modelBuilder.Entity("DataLayer.Inspector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Department");

                    b.Property<string>("Name");

                    b.Property<string>("Subdivision");

                    b.HasKey("Id");

                    b.ToTable("Inspectors");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.BronzeSleeveShutterJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("DetailId");

                    b.Property<string>("DetailName");

                    b.Property<string>("DetailNumber");

                    b.Property<int?>("InspectorId");

                    b.Property<string>("Point");

                    b.Property<int?>("PointId");

                    b.Property<string>("Remark");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("InspectorId");

                    b.HasIndex("PointId");

                    b.ToTable("BronzeSleeveShutterJournals");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.CaseShutterJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("DetailId");

                    b.Property<string>("DetailName");

                    b.Property<string>("DetailNumber");

                    b.Property<int?>("InspectorId");

                    b.Property<string>("Point");

                    b.Property<int?>("PointId");

                    b.Property<string>("Remark");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("InspectorId");

                    b.HasIndex("PointId");

                    b.ToTable("CaseShutterJournals");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.NozzleJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("DetailId");

                    b.Property<string>("DetailName");

                    b.Property<string>("DetailNumber");

                    b.Property<int?>("InspectorId");

                    b.Property<string>("Point");

                    b.Property<int?>("PointId");

                    b.Property<string>("Remark");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("InspectorId");

                    b.HasIndex("PointId");

                    b.ToTable("NozzleJournals");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.ShaftShutterJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("DetailId");

                    b.Property<string>("DetailName");

                    b.Property<string>("DetailNumber");

                    b.Property<int?>("InspectorId");

                    b.Property<string>("Point");

                    b.Property<int?>("PointId");

                    b.Property<string>("Remark");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("InspectorId");

                    b.HasIndex("PointId");

                    b.ToTable("ShaftShutterJournals");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.ShutterReverseJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("DetailId");

                    b.Property<string>("DetailName");

                    b.Property<string>("DetailNumber");

                    b.Property<int?>("InspectorId");

                    b.Property<string>("Point");

                    b.Property<int?>("PointId");

                    b.Property<string>("Remark");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("InspectorId");

                    b.HasIndex("PointId");

                    b.ToTable("ShutterReverseJournals");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.SlamShutterJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("DetailId");

                    b.Property<string>("DetailName");

                    b.Property<string>("DetailNumber");

                    b.Property<int?>("InspectorId");

                    b.Property<string>("Point");

                    b.Property<int?>("PointId");

                    b.Property<string>("Remark");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("InspectorId");

                    b.HasIndex("PointId");

                    b.ToTable("SlamShutterJournals");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.SteelSleeveShutterJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("DetailId");

                    b.Property<string>("DetailName");

                    b.Property<string>("DetailNumber");

                    b.Property<int?>("InspectorId");

                    b.Property<string>("Point");

                    b.Property<int?>("PointId");

                    b.Property<string>("Remark");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("InspectorId");

                    b.HasIndex("PointId");

                    b.ToTable("SteelSleeveShutterJournals");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.StubShutterJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("DetailId");

                    b.Property<string>("DetailName");

                    b.Property<string>("DetailNumber");

                    b.Property<int?>("InspectorId");

                    b.Property<string>("Point");

                    b.Property<int?>("PointId");

                    b.Property<string>("Remark");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DetailId");

                    b.HasIndex("InspectorId");

                    b.HasIndex("PointId");

                    b.ToTable("StubShutterJournals");
                });

            modelBuilder.Entity("DataLayer.PID", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amount");

                    b.Property<string>("Climatic");

                    b.Property<string>("ConnectionType");

                    b.Property<string>("DN");

                    b.Property<string>("DriveType");

                    b.Property<string>("EarthquakeResistance");

                    b.Property<string>("Number");

                    b.Property<string>("PN");

                    b.Property<int?>("ProductTypeId");

                    b.Property<DateTime?>("ShippingDate");

                    b.Property<int?>("SpecificationId");

                    b.Property<string>("TechDocumentation");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("SpecificationId");

                    b.ToTable("PIDs");
                });

            modelBuilder.Entity("DataLayer.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("DataLayer.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Consignee");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Facility");

                    b.Property<string>("Number");

                    b.Property<string>("Program");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("DataLayer.TechnicalControlPlans.AssemblyUnits.ShutterReverseTCP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("OperationName");

                    b.Property<string>("Point");

                    b.HasKey("Id");

                    b.ToTable("ShutterReverseTCPs");
                });

            modelBuilder.Entity("DataLayer.TechnicalControlPlans.Detailing.BronzeSleeveShutterTCP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("OperationName");

                    b.Property<string>("Point");

                    b.HasKey("Id");

                    b.ToTable("BronzeSleeveShutterTCPs");
                });

            modelBuilder.Entity("DataLayer.TechnicalControlPlans.Detailing.CaseShutterTCP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("OperationName");

                    b.Property<string>("Point");

                    b.HasKey("Id");

                    b.ToTable("CaseShutterTCPs");
                });

            modelBuilder.Entity("DataLayer.TechnicalControlPlans.Detailing.NozzleTCP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("OperationName");

                    b.Property<string>("Point");

                    b.HasKey("Id");

                    b.ToTable("NozzleTCPs");
                });

            modelBuilder.Entity("DataLayer.TechnicalControlPlans.Detailing.ShaftShutterTCP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("OperationName");

                    b.Property<string>("Point");

                    b.HasKey("Id");

                    b.ToTable("ShaftShutterTCPs");
                });

            modelBuilder.Entity("DataLayer.TechnicalControlPlans.Detailing.SlamShutterTCP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("OperationName");

                    b.Property<string>("Point");

                    b.HasKey("Id");

                    b.ToTable("SlamShutterTCPs");
                });

            modelBuilder.Entity("DataLayer.TechnicalControlPlans.Detailing.SteelSleeveShutterTCP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("OperationName");

                    b.Property<string>("Point");

                    b.HasKey("Id");

                    b.ToTable("SteelSleeveShutterTCPs");
                });

            modelBuilder.Entity("DataLayer.TechnicalControlPlans.Detailing.StubShutterTCP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("OperationName");

                    b.Property<string>("Point");

                    b.HasKey("Id");

                    b.ToTable("StubShutterTCPs");
                });

            modelBuilder.Entity("DataLayer.Entities.AssemblyUnits.ShutterReverse", b =>
                {
                    b.HasOne("DataLayer.Entities.Detailing.CaseShutter")
                        .WithMany("ShutterReverses")
                        .HasForeignKey("CaseShutterId");

                    b.HasOne("DataLayer.Entities.Detailing.BronzeSleeveShutter", "FirstBronzeSleeveShutter")
                        .WithMany("FirstShutterReverses")
                        .HasForeignKey("FirstBronzeSleeveShutterId");

                    b.HasOne("DataLayer.Entities.Detailing.SteelSleeveShutter", "FirstSteelSleeveShutter")
                        .WithMany("FirstShutterReverses")
                        .HasForeignKey("FirstSteelSleeveShutterId");

                    b.HasOne("DataLayer.Entities.Detailing.StubShutter", "FirstStubShutter")
                        .WithMany("FirstShutterReverses")
                        .HasForeignKey("FirstStubShutterId");

                    b.HasOne("DataLayer.PID")
                        .WithMany("ShutterReverses")
                        .HasForeignKey("PIDId");

                    b.HasOne("DataLayer.Entities.Detailing.BronzeSleeveShutter", "SecondBronzeSleeveShutter")
                        .WithMany("SecondShutterReverses")
                        .HasForeignKey("SecondBronzeSleeveShutterId");

                    b.HasOne("DataLayer.Entities.Detailing.SteelSleeveShutter", "SecondSteelSleeveShutter")
                        .WithMany("SecondShutterReverses")
                        .HasForeignKey("SecondSteelSleeveShutterId");

                    b.HasOne("DataLayer.Entities.Detailing.StubShutter", "SecondStubShutter")
                        .WithMany("SecondShutterReverses")
                        .HasForeignKey("SecondStubShutterId");

                    b.HasOne("DataLayer.Entities.Detailing.ShaftShutter")
                        .WithMany("ShutterReverses")
                        .HasForeignKey("ShaftShutterId");

                    b.HasOne("DataLayer.Entities.Detailing.SlamShutter")
                        .WithMany("ShutterReverses")
                        .HasForeignKey("SlamShutterId");
                });

            modelBuilder.Entity("DataLayer.Entities.Detailing.CaseShutter", b =>
                {
                    b.HasOne("DataLayer.Entities.Detailing.Nozzle", "FirstNozzle")
                        .WithMany("FirstCaseShutters")
                        .HasForeignKey("FirstNozzleId");

                    b.HasOne("DataLayer.Entities.Detailing.Nozzle", "SecondNozzle")
                        .WithMany("SecondCaseShutters")
                        .HasForeignKey("SecondNozzleId");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.BronzeSleeveShutterJournal", b =>
                {
                    b.HasOne("DataLayer.Entities.Detailing.BronzeSleeveShutter", "Entity")
                        .WithMany("BronzeSleeveShutterJournals")
                        .HasForeignKey("DetailId");

                    b.HasOne("DataLayer.Inspector")
                        .WithMany("BronzeSleeveShutterJournals")
                        .HasForeignKey("InspectorId");

                    b.HasOne("DataLayer.TechnicalControlPlans.Detailing.BronzeSleeveShutterTCP", "EntityTCP")
                        .WithMany("BronzeSleeveShutterJournals")
                        .HasForeignKey("PointId");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.CaseShutterJournal", b =>
                {
                    b.HasOne("DataLayer.Entities.Detailing.CaseShutter", "Entity")
                        .WithMany("CaseShutterJournals")
                        .HasForeignKey("DetailId");

                    b.HasOne("DataLayer.Inspector")
                        .WithMany("CaseShutterJournals")
                        .HasForeignKey("InspectorId");

                    b.HasOne("DataLayer.TechnicalControlPlans.Detailing.CaseShutterTCP", "EntityTCP")
                        .WithMany("CaseShutterJournals")
                        .HasForeignKey("PointId");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.NozzleJournal", b =>
                {
                    b.HasOne("DataLayer.Entities.Detailing.Nozzle", "Entity")
                        .WithMany("NozzleJournals")
                        .HasForeignKey("DetailId");

                    b.HasOne("DataLayer.Inspector")
                        .WithMany("NozzleJournals")
                        .HasForeignKey("InspectorId");

                    b.HasOne("DataLayer.TechnicalControlPlans.Detailing.NozzleTCP", "EntityTCP")
                        .WithMany("NozzleJournals")
                        .HasForeignKey("PointId");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.ShaftShutterJournal", b =>
                {
                    b.HasOne("DataLayer.Entities.Detailing.ShaftShutter", "Entity")
                        .WithMany("ShaftShutterJournals")
                        .HasForeignKey("DetailId");

                    b.HasOne("DataLayer.Inspector")
                        .WithMany("ShaftShutterJournals")
                        .HasForeignKey("InspectorId");

                    b.HasOne("DataLayer.TechnicalControlPlans.Detailing.ShaftShutterTCP", "EntityTCP")
                        .WithMany("ShaftShutterJournals")
                        .HasForeignKey("PointId");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.ShutterReverseJournal", b =>
                {
                    b.HasOne("DataLayer.Entities.AssemblyUnits.ShutterReverse", "Entity")
                        .WithMany("ShutterReverseJournals")
                        .HasForeignKey("DetailId");

                    b.HasOne("DataLayer.Inspector")
                        .WithMany("ShutterReverseJournals")
                        .HasForeignKey("InspectorId");

                    b.HasOne("DataLayer.TechnicalControlPlans.AssemblyUnits.ShutterReverseTCP", "EntityTCP")
                        .WithMany("ShutterReverseJournals")
                        .HasForeignKey("PointId");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.SlamShutterJournal", b =>
                {
                    b.HasOne("DataLayer.Entities.Detailing.SlamShutter", "Entity")
                        .WithMany("SlamShutterJournals")
                        .HasForeignKey("DetailId");

                    b.HasOne("DataLayer.Inspector")
                        .WithMany("SlamShutterJournals")
                        .HasForeignKey("InspectorId");

                    b.HasOne("DataLayer.TechnicalControlPlans.Detailing.SlamShutterTCP", "EntityTCP")
                        .WithMany("SlamShutterJournals")
                        .HasForeignKey("PointId");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.SteelSleeveShutterJournal", b =>
                {
                    b.HasOne("DataLayer.Entities.Detailing.SteelSleeveShutter", "Entity")
                        .WithMany("SteelSleeveShutterJournals")
                        .HasForeignKey("DetailId");

                    b.HasOne("DataLayer.Inspector")
                        .WithMany("SteelSleeveShutterJournals")
                        .HasForeignKey("InspectorId");

                    b.HasOne("DataLayer.TechnicalControlPlans.Detailing.SteelSleeveShutterTCP", "EntityTCP")
                        .WithMany("SteelSleeveShutterJournals")
                        .HasForeignKey("PointId");
                });

            modelBuilder.Entity("DataLayer.Journals.Detailing.StubShutterJournal", b =>
                {
                    b.HasOne("DataLayer.Entities.Detailing.StubShutter", "Entity")
                        .WithMany("StubShutterJournals")
                        .HasForeignKey("DetailId");

                    b.HasOne("DataLayer.Inspector")
                        .WithMany("StubShutterJournals")
                        .HasForeignKey("InspectorId");

                    b.HasOne("DataLayer.TechnicalControlPlans.Detailing.StubShutterTCP", "EntityTCP")
                        .WithMany("StubShutterJournals")
                        .HasForeignKey("PointId");
                });

            modelBuilder.Entity("DataLayer.PID", b =>
                {
                    b.HasOne("DataLayer.ProductType")
                        .WithMany("PIDs")
                        .HasForeignKey("ProductTypeId");

                    b.HasOne("DataLayer.Specification")
                        .WithMany("PIDs")
                        .HasForeignKey("SpecificationId");
                });

            modelBuilder.Entity("DataLayer.Specification", b =>
                {
                    b.HasOne("DataLayer.Customer")
                        .WithMany("Specifications")
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}

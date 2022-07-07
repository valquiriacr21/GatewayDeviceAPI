﻿// <auto-generated />
using System;
using GatewayDeviceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GatewayDeviceAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220706040233_AccommodatingSpaceMaxLength")]
    partial class AccommodatingSpaceMaxLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GatewayDeviceAPI.Models.Device", b =>
                {
                    b.Property<int>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("GatewaySerialNumber")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Vendor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UID");

                    b.HasIndex("GatewaySerialNumber");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("GatewayDeviceAPI.Models.Gateway", b =>
                {
                    b.Property<int>("SerialNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IPV4")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SerialNumber");

                    b.ToTable("Gateways");
                });

            modelBuilder.Entity("GatewayDeviceAPI.Models.Device", b =>
                {
                    b.HasOne("GatewayDeviceAPI.Models.Gateway", null)
                        .WithMany("Devices")
                        .HasForeignKey("GatewaySerialNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GatewayDeviceAPI.Models.Gateway", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}

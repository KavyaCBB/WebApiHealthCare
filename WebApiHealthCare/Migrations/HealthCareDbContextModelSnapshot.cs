﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiHealthCare.Data;

namespace WebApiHealthCare.Migrations
{
    [DbContext(typeof(HealthCareDbContext))]
    partial class HealthCareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiHealthCare.Data.Login", b =>
                {
                    b.Property<int>("Loginid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialLoginType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Loginid");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("WebApiHealthCare.Data.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebApiHealthCare.Data.Staffs", b =>
                {
                    b.Property<int>("StaffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Loginid")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("StaffName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("StaffID");

                    b.HasIndex("Loginid");

                    b.HasIndex("RoleId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("WebApiHealthCare.Data.TestResults", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Loginid")
                        .HasColumnType("int");

                    b.Property<float>("MaxRange")
                        .HasColumnType("real");

                    b.Property<float>("MinRange")
                        .HasColumnType("real");

                    b.Property<float>("PatientRange")
                        .HasColumnType("real");

                    b.Property<string>("TestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("TestId");

                    b.HasIndex("Loginid");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("WebApiHealthCare.Data.Staffs", b =>
                {
                    b.HasOne("WebApiHealthCare.Data.Login", "Login")
                        .WithMany()
                        .HasForeignKey("Loginid");

                    b.HasOne("WebApiHealthCare.Data.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("WebApiHealthCare.Data.TestResults", b =>
                {
                    b.HasOne("WebApiHealthCare.Data.Login", "Login")
                        .WithMany()
                        .HasForeignKey("Loginid");
                });
#pragma warning restore 612, 618
        }
    }
}

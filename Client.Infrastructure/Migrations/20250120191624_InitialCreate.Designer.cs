﻿// <auto-generated />
using System;
using Client.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Client.Infrastructure.Migrations
{
    [DbContext(typeof(ClientDbContext))]
    [Migration("20250120191624_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate.RichClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("RichClients", (string)null);
                });

            modelBuilder.Entity("Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate.RichClient", b =>
                {
                    b.OwnsMany("Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate.RichAddress", "AddressContacts", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("ApartmentNumber")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("ApartmentNumber");

                            b1.Property<string>("BuildingNumber")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("BuildingNumber");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("City");

                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ClientId");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Country");

                            b1.Property<string>("PostCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("PostCode");

                            b1.Property<int>("RichClientId")
                                .HasColumnType("int");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Street");

                            b1.HasKey("Id");

                            b1.HasIndex("RichClientId");

                            b1.ToTable("RichClientAddresses", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("RichClientId");
                        });

                    b.OwnsMany("Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate.RichEmail", "EmailContacts", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ClientId");

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Content");

                            b1.Property<string>("Domain")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Domain");

                            b1.Property<int>("RichClientId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("RichClientId");

                            b1.ToTable("RichClientEmails", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("RichClientId");
                        });

                    b.OwnsMany("Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate.RichPhone", "PhoneContacts", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ClientId");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("Number");

                            b1.Property<string>("Prefix")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)")
                                .HasColumnName("Prefix");

                            b1.Property<int>("RichClientId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("RichClientId");

                            b1.ToTable("RichClientPhones", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("RichClientId");
                        });

                    b.Navigation("AddressContacts");

                    b.Navigation("EmailContacts");

                    b.Navigation("PhoneContacts");
                });
#pragma warning restore 612, 618
        }
    }
}

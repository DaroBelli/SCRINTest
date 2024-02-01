﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCRINTest.Context;

#nullable disable

namespace SCRINTest.Migrations
{
    [DbContext(typeof(ScrintestContext))]
    [Migration("20240201101249_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SCRINTest.Models.DB.BuyingProduct", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("ClientNavigationId")
                        .HasColumnType("int");

                    b.Property<int?>("Count")
                        .HasColumnType("int")
                        .HasColumnName("count");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("PlacementDate")
                        .HasColumnType("date")
                        .HasColumnName("placementDate");

                    b.HasKey("Id")
                        .HasName("PK__BuyingPr__3213E83F1BF030E1");

                    b.HasIndex("ClientNavigationId");

                    b.ToTable("BuyingProducts");
                });

            modelBuilder.Entity("SCRINTest.Models.DB.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SCRINTest.Models.DB.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Count")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("price");

                    b.Property<string>("UnitMeasurement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Products__3213E83F0F5A9EF5");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SCRINTest.Models.DB.ProductsByuingProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdByuingProduct")
                        .HasColumnType("int")
                        .HasColumnName("idByuingProduct");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int")
                        .HasColumnName("idProduct");

                    b.HasKey("Id")
                        .HasName("PK__Orders__3213E83F83D91EEE");

                    b.HasIndex("IdByuingProduct");

                    b.HasIndex("IdProduct");

                    b.ToTable("Products_ByuingProducts", (string)null);
                });

            modelBuilder.Entity("SCRINTest.Models.DB.BuyingProduct", b =>
                {
                    b.HasOne("SCRINTest.Models.DB.Client", "ClientNavigation")
                        .WithMany("BuyingProducts")
                        .HasForeignKey("ClientNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientNavigation");
                });

            modelBuilder.Entity("SCRINTest.Models.DB.ProductsByuingProduct", b =>
                {
                    b.HasOne("SCRINTest.Models.DB.BuyingProduct", "ByuingProductNavigation")
                        .WithMany("ProductsByuingProducts")
                        .HasForeignKey("IdByuingProduct")
                        .HasConstraintName("FK__Orders__buyingPr__3B75D760");

                    b.HasOne("SCRINTest.Models.DB.Product", "ProductNavigation")
                        .WithMany("ProductsByuingProducts")
                        .HasForeignKey("IdProduct")
                        .HasConstraintName("FK__Orders__productI__3A81B327");

                    b.Navigation("ByuingProductNavigation");

                    b.Navigation("ProductNavigation");
                });

            modelBuilder.Entity("SCRINTest.Models.DB.BuyingProduct", b =>
                {
                    b.Navigation("ProductsByuingProducts");
                });

            modelBuilder.Entity("SCRINTest.Models.DB.Client", b =>
                {
                    b.Navigation("BuyingProducts");
                });

            modelBuilder.Entity("SCRINTest.Models.DB.Product", b =>
                {
                    b.Navigation("ProductsByuingProducts");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataModel.Migrations
{
    [DbContext(typeof(MycitiesContext))]
    [Migration("20241004222416_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataModel.City", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Countryid")
                        .HasColumnType("int")
                        .HasColumnName("countryid");

                    b.Property<double>("Lat")
                        .HasColumnType("float")
                        .HasColumnName("lat");

                    b.Property<double>("Lng")
                        .HasColumnType("float")
                        .HasColumnName("lng");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("Population")
                        .HasColumnType("int")
                        .HasColumnName("population");

                    b.HasKey("Id");

                    b.HasIndex("Countryid");

                    b.ToTable("City");
                });

            modelBuilder.Entity("DataModel.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Iso2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .HasColumnName("iso2")
                        .IsFixedLength();

                    b.Property<string>("Iso3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .HasColumnName("iso3")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("DataModel.City", b =>
                {
                    b.HasOne("DataModel.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("Countryid")
                        .IsRequired()
                        .HasConstraintName("FK_City_Country");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DataModel.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}

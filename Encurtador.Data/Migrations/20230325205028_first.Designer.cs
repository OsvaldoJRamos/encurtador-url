﻿// <auto-generated />
using System;
using Encurtador.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Encurtador.Data.Migrations
{
    [DbContext(typeof(EncurtadorContext))]
    [Migration("20230325205028_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Encurtador.Domain.Entities.Click", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("EncurtadoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EncurtadoId");

                    b.ToTable("Click");
                });

            modelBuilder.Entity("Encurtador.Domain.Entities.Encurtado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NumeroCliques")
                        .HasColumnType("int");

                    b.Property<string>("UrlEncurtada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UrlOriginal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Encurtado");
                });

            modelBuilder.Entity("Encurtador.Domain.Entities.Click", b =>
                {
                    b.HasOne("Encurtador.Domain.Entities.Encurtado", null)
                        .WithMany("Clicks")
                        .HasForeignKey("EncurtadoId");
                });

            modelBuilder.Entity("Encurtador.Domain.Entities.Encurtado", b =>
                {
                    b.Navigation("Clicks");
                });
#pragma warning restore 612, 618
        }
    }
}

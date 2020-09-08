﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PontoEletronico.Repository;

namespace PontoEletronico.Repository.Migrations
{
    [DbContext(typeof(PontoEletronicoContext))]
    [Migration("20200831012604_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("PontoEletronico.Domain.PontoRegistro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<char>("EntradaSaida")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Registro")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PontoRegistros");
                });
#pragma warning restore 612, 618
        }
    }
}
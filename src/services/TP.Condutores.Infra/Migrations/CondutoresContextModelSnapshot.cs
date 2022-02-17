﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP.Condutores.Infra.Data;

namespace TP.Condutores.Infra.Migrations
{
    [DbContext(typeof(CondutoresContext))]
    partial class CondutoresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TP.Condutores.Domain.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CNH");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Telefone");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Condutor");
                });

            modelBuilder.Entity("TP.Condutores.Domain.VeiculoCondutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CondutorId")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasColumnName("CondutorId");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Placa");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("VeiculosCondutores", b =>
                {
                    b.Property<Guid>("CondutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CondutorId", "VeiculoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("VeiculosCondutores");
                });

            modelBuilder.Entity("TP.Condutores.Domain.Condutor", b =>
                {
                    b.OwnsOne("TP.Core.DomainObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("CondutorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("PrimeiroNome");

                            b1.Property<string>("UltimoNome")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("UltimoNome");

                            b1.HasKey("CondutorId");

                            b1.ToTable("Condutor");

                            b1.WithOwner()
                                .HasForeignKey("CondutorId");
                        });

                    b.Navigation("Nome");
                });

            modelBuilder.Entity("VeiculosCondutores", b =>
                {
                    b.HasOne("TP.Condutores.Domain.VeiculoCondutor", null)
                        .WithMany()
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP.Condutores.Domain.Condutor", null)
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

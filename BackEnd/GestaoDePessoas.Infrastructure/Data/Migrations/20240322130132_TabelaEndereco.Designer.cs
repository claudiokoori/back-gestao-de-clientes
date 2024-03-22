﻿// <auto-generated />
using System;
using GestaoDeClientes.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestaoDeClientes.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240322130132_TabelaEndereco")]
    partial class TabelaEndereco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestaoDeClientes.Domain.Model.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("cpf");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int")
                        .HasColumnName("endereco_id");

                    b.Property<int>("Genero")
                        .HasColumnType("int")
                        .HasColumnName("genero");

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome_completo");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("telefone");

                    b.HasKey("Id")
                        .HasName("pk_clientes");

                    b.HasIndex("CPF")
                        .IsUnique()
                        .HasDatabaseName("ix_clientes_cpf")
                        .HasFilter("[cpf] IS NOT NULL");

                    b.HasIndex("EnderecoId")
                        .IsUnique()
                        .HasDatabaseName("ix_clientes_endereco_id")
                        .HasFilter("[endereco_id] IS NOT NULL");

                    b.HasIndex("Telefone")
                        .IsUnique()
                        .HasDatabaseName("ix_clientes_telefone")
                        .HasFilter("[telefone] IS NOT NULL");

                    b.ToTable("clientes", (string)null);
                });

            modelBuilder.Entity("GestaoDeClientes.Domain.Model.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("bairro")
                        .HasAnnotation("Relational:JsonPropertyName", "bairro");

                    b.Property<string>("Casa")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("casa")
                        .HasAnnotation("Relational:JsonPropertyName", "casa");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cep")
                        .HasAnnotation("Relational:JsonPropertyName", "cep");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("complemento")
                        .HasAnnotation("Relational:JsonPropertyName", "complemento");

                    b.Property<string>("Ddd")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ddd")
                        .HasAnnotation("Relational:JsonPropertyName", "ddd");

                    b.Property<string>("Gia")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gia")
                        .HasAnnotation("Relational:JsonPropertyName", "gia");

                    b.Property<string>("Ibge")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ibge")
                        .HasAnnotation("Relational:JsonPropertyName", "ibge");

                    b.Property<string>("Localidade")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("localidade")
                        .HasAnnotation("Relational:JsonPropertyName", "localidade");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("logradouro")
                        .HasAnnotation("Relational:JsonPropertyName", "logradouro");

                    b.Property<string>("Siafi")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("siafi")
                        .HasAnnotation("Relational:JsonPropertyName", "siafi");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("uf")
                        .HasAnnotation("Relational:JsonPropertyName", "uf");

                    b.HasKey("Id")
                        .HasName("pk_endereco");

                    b.ToTable("endereco", (string)null);
                });

            modelBuilder.Entity("GestaoDeClientes.Domain.Model.Cliente", b =>
                {
                    b.HasOne("GestaoDeClientes.Domain.Model.Endereco", "Endereco")
                        .WithOne("Cliente")
                        .HasForeignKey("GestaoDeClientes.Domain.Model.Cliente", "EnderecoId")
                        .HasConstraintName("fk_clientes_endereco_endereco_id");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("GestaoDeClientes.Domain.Model.Endereco", b =>
                {
                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
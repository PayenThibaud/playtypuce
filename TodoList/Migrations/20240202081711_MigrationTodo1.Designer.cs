﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.NET.Data;

#nullable disable

namespace TodoList.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240202081711_MigrationTodo1")]
    partial class MigrationTodo1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TodoList.Models.TodoListClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatutEnCours")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("todoListClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Préparer la venue de belle-maman",
                            StatutEnCours = 1,
                            Titre = "Rangement"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Promener Médor et faire attention au chien de la voisine",
                            StatutEnCours = 0,
                            Titre = "Promenade"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

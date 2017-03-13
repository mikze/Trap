using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication4.Models;

namespace WebApplication4.Migrations
{
    [DbContext(typeof(TrapContext))]
    [Migration("20160808175002_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication4.Models.Trap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Battery");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("FirstRat");

                    b.Property<DateTime>("LastMadified");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int>("Rats");

                    b.Property<int>("Trapid");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Traps");
                });
        }
    }
}

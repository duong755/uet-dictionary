﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UetDictionaryCli.Models;

namespace UetDictionaryCli.Migrations
{
    [DbContext(typeof(DictionaryContext))]
    [Migration("20181023155206_DictionaryMigration")]
    partial class DictionaryMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("UetDictionaryCli.Models.Word", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InEnglish")
                        .IsRequired();

                    b.Property<string>("InVietnamese")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
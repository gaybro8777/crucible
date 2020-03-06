/*
Crucible
Copyright 2020 Carnegie Mellon University.
NO WARRANTY. THIS CARNEGIE MELLON UNIVERSITY AND SOFTWARE ENGINEERING INSTITUTE MATERIAL IS FURNISHED ON AN "AS-IS" BASIS. CARNEGIE MELLON UNIVERSITY MAKES NO WARRANTIES OF ANY KIND, EITHER EXPRESSED OR IMPLIED, AS TO ANY MATTER INCLUDING, BUT NOT LIMITED TO, WARRANTY OF FITNESS FOR PURPOSE OR MERCHANTABILITY, EXCLUSIVITY, OR RESULTS OBTAINED FROM USE OF THE MATERIAL. CARNEGIE MELLON UNIVERSITY DOES NOT MAKE ANY WARRANTY OF ANY KIND WITH RESPECT TO FREEDOM FROM PATENT, TRADEMARK, OR COPYRIGHT INFRINGEMENT.
Released under a MIT (SEI)-style license, please see license.txt or contact permission@sei.cmu.edu for full terms.
[DISTRIBUTION STATEMENT A] This material has been approved for public release and unlimited distribution.  Please see Copyright notice for non-US Government use and distribution.
Carnegie Mellon� and CERT� are registered in the U.S. Patent and Trademark Office by Carnegie Mellon University.
DM20-0181
*/

// <auto-generated />
using System;
using Caster.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Caster.Api.Data.Migrations
{
    [DbContext(typeof(CasterContext))]
    [Migration("20190305205435_Changed_Configuration_File_Content_To_String")]
    partial class Changed_Configuration_File_Content_To_String
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Caster.Api.Domain.Models.ConfigurationFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Content")
                        .HasColumnName("content");

                    b.Property<Guid>("DirectoryId")
                        .HasColumnName("directory_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryId");

                    b.ToTable("configuration_files");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Directory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnName("exercise_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<bool>("Shared")
                        .HasColumnName("shared");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("directories");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("exercises");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Workspace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid?>("DirectoryId")
                        .HasColumnName("directory_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<byte[]>("State")
                        .HasColumnName("state");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryId");

                    b.ToTable("workspaces");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.ConfigurationFile", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Directory", "Directory")
                        .WithMany("Configurations")
                        .HasForeignKey("DirectoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Directory", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Exercise", "Exercise")
                        .WithMany("Directories")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Workspace", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Directory")
                        .WithMany("Workspaces")
                        .HasForeignKey("DirectoryId");
                });
#pragma warning restore 612, 618
        }
    }
}


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
    [Migration("20191010132816_default_directory_path")]
    partial class default_directory_path
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Caster.Api.Domain.Models.Apply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Output")
                        .HasColumnName("output");

                    b.Property<Guid>("RunId")
                        .HasColumnName("run_id");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("RunId")
                        .IsUnique();

                    b.ToTable("applies");
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

                    b.Property<Guid?>("ParentId")
                        .HasColumnName("parent_id");

                    b.Property<string>("Path")
                        .HasColumnName("path");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("ParentId");

                    b.HasIndex("Path");

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

            modelBuilder.Entity("Caster.Api.Domain.Models.File", b =>
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

                    b.Property<Guid?>("WorkspaceId")
                        .HasColumnName("workspace_id");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryId");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("files");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Path")
                        .HasColumnName("path");

                    b.HasKey("Id");

                    b.ToTable("modules");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.ModuleVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("ModuleId")
                        .HasColumnName("module_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Outputs")
                        .HasColumnName("outputs");

                    b.Property<string>("UrlLink")
                        .HasColumnName("url_link");

                    b.Property<string>("Variables")
                        .HasColumnName("variables");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("module_versions");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Output")
                        .HasColumnName("output");

                    b.Property<Guid>("RunId")
                        .HasColumnName("run_id");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("RunId")
                        .IsUnique();

                    b.ToTable("plans");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.RemovedResource", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.HasKey("Id");

                    b.ToTable("removed_resources");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Run", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDestroy")
                        .HasColumnName("is_destroy");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.Property<string>("Targets")
                        .HasColumnName("targets");

                    b.Property<Guid>("WorkspaceId")
                        .HasColumnName("workspace_id");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("runs");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Workspace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("DirectoryId")
                        .HasColumnName("directory_id");

                    b.Property<DateTime?>("LastSynced")
                        .HasColumnName("last_synced");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("State")
                        .HasColumnName("state");

                    b.Property<string>("StateBackup")
                        .HasColumnName("state_backup");

                    b.Property<string>("SyncErrors")
                        .HasColumnName("sync_errors");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryId");

                    b.ToTable("workspaces");
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Apply", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Run", "Run")
                        .WithOne("Apply")
                        .HasForeignKey("Caster.Api.Domain.Models.Apply", "RunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Directory", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Exercise", "Exercise")
                        .WithMany("Directories")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Caster.Api.Domain.Models.Directory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.File", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Directory", "Directory")
                        .WithMany("Files")
                        .HasForeignKey("DirectoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Caster.Api.Domain.Models.Workspace", "Workspace")
                        .WithMany("Files")
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.ModuleVersion", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Module", "Module")
                        .WithMany("Versions")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Plan", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Run", "Run")
                        .WithOne("Plan")
                        .HasForeignKey("Caster.Api.Domain.Models.Plan", "RunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Run", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Workspace", "Workspace")
                        .WithMany("Runs")
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Caster.Api.Domain.Models.Workspace", b =>
                {
                    b.HasOne("Caster.Api.Domain.Models.Directory", "Directory")
                        .WithMany("Workspaces")
                        .HasForeignKey("DirectoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}


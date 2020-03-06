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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using S3.Player.Api.Data.Data;

namespace S3.Player.Api.Migrations.PostgreSQL.Migrations
{
    [DbContext(typeof(PlayerContext))]
    [Migration("20180822200200_Added_Permissions")]
    partial class Added_Permissions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.ApplicationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid?>("ApplicationTemplateId")
                        .HasColumnName("application_template_id");

                    b.Property<bool?>("Embeddable")
                        .HasColumnName("embeddable");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnName("exercise_id");

                    b.Property<string>("Icon")
                        .HasColumnName("icon");

                    b.Property<bool?>("LoadInBackground")
                        .HasColumnName("load_in_background");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Url")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationTemplateId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("applications");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.ApplicationInstanceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnName("application_id");

                    b.Property<float>("DisplayOrder")
                        .HasColumnName("display_order");

                    b.Property<Guid>("TeamId")
                        .HasColumnName("team_id");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("TeamId");

                    b.ToTable("application_instances");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.ApplicationTemplateEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<bool>("Embeddable")
                        .HasColumnName("embeddable");

                    b.Property<string>("Icon")
                        .HasColumnName("icon");

                    b.Property<bool>("LoadInBackground")
                        .HasColumnName("load_in_background");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Url")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.ToTable("application_templates");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.ExerciseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("exercises");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.ExerciseMembershipEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnName("exercise_id");

                    b.Property<Guid>("PrimaryTeamMembershipId")
                        .HasColumnName("primary_team_membership_id");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryTeamMembershipId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.HasIndex("ExerciseId", "UserId")
                        .IsUnique();

                    b.ToTable("exercise_memberships");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.NotificationEntity", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("key");

                    b.Property<DateTime>("BroadcastTime")
                        .HasColumnName("broadcast_time");

                    b.Property<Guid?>("ExerciseId")
                        .HasColumnName("exercise_id");

                    b.Property<Guid>("FromId")
                        .HasColumnName("from_id");

                    b.Property<string>("FromName")
                        .HasColumnName("from_name");

                    b.Property<int>("FromType")
                        .HasColumnName("from_type");

                    b.Property<string>("Link")
                        .HasColumnName("link");

                    b.Property<int>("Priority")
                        .HasColumnName("priority");

                    b.Property<string>("Subject")
                        .HasColumnName("subject");

                    b.Property<string>("Text")
                        .HasColumnName("text");

                    b.Property<Guid>("ToId")
                        .HasColumnName("to_id");

                    b.Property<string>("ToName")
                        .HasColumnName("to_name");

                    b.Property<int>("ToType")
                        .HasColumnName("to_type");

                    b.HasKey("Key");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.PermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("Key")
                        .HasColumnName("key");

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("Key", "Value")
                        .IsUnique();

                    b.ToTable("permissions");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.RolePermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("PermissionId")
                        .HasColumnName("permission_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId", "PermissionId")
                        .IsUnique();

                    b.ToTable("role_permissions");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnName("exercise_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<Guid?>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("RoleId");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.TeamMembershipEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid?>("ExerciseMembershipEntityId")
                        .HasColumnName("exercise_membership_entity_id");

                    b.Property<Guid>("ExerciseMembershipId")
                        .HasColumnName("exercise_membership_id");

                    b.Property<Guid?>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<Guid>("TeamId")
                        .HasColumnName("team_id");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseMembershipEntityId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.HasIndex("TeamId", "UserId")
                        .IsUnique();

                    b.ToTable("team_memberships");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.TeamPermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("PermissionId")
                        .HasColumnName("permission_id");

                    b.Property<Guid>("TeamId")
                        .HasColumnName("team_id");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("TeamId", "PermissionId")
                        .IsUnique();

                    b.ToTable("team_permissions");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.UserEntity", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("key");

                    b.Property<Guid>("Id")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<Guid?>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("Key");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.UserPermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("PermissionId")
                        .HasColumnName("permission_id");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.Property<int?>("UserKey")
                        .HasColumnName("user_key");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserKey");

                    b.HasIndex("UserId", "PermissionId")
                        .IsUnique();

                    b.ToTable("user_permissions");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.ApplicationEntity", b =>
                {
                    b.HasOne("S3.Player.Api.Data.Data.Models.ApplicationTemplateEntity", "Template")
                        .WithMany()
                        .HasForeignKey("ApplicationTemplateId");

                    b.HasOne("S3.Player.Api.Data.Data.Models.ExerciseEntity", "Exercise")
                        .WithMany("Applications")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.ApplicationInstanceEntity", b =>
                {
                    b.HasOne("S3.Player.Api.Data.Data.Models.ApplicationEntity", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S3.Player.Api.Data.Data.Models.TeamEntity", "Team")
                        .WithMany("Applications")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.ExerciseMembershipEntity", b =>
                {
                    b.HasOne("S3.Player.Api.Data.Data.Models.ExerciseEntity", "Exercise")
                        .WithMany("Memberships")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S3.Player.Api.Data.Data.Models.TeamMembershipEntity", "PrimaryTeamMembership")
                        .WithOne("ExerciseMembership")
                        .HasForeignKey("S3.Player.Api.Data.Data.Models.ExerciseMembershipEntity", "PrimaryTeamMembershipId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S3.Player.Api.Data.Data.Models.UserEntity", "User")
                        .WithMany("ExerciseMemberships")
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.RolePermissionEntity", b =>
                {
                    b.HasOne("S3.Player.Api.Data.Data.Models.PermissionEntity", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S3.Player.Api.Data.Data.Models.RoleEntity", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.TeamEntity", b =>
                {
                    b.HasOne("S3.Player.Api.Data.Data.Models.ExerciseEntity", "Exercise")
                        .WithMany("Teams")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S3.Player.Api.Data.Data.Models.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.TeamMembershipEntity", b =>
                {
                    b.HasOne("S3.Player.Api.Data.Data.Models.ExerciseMembershipEntity")
                        .WithMany("TeamMemberships")
                        .HasForeignKey("ExerciseMembershipEntityId");

                    b.HasOne("S3.Player.Api.Data.Data.Models.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("S3.Player.Api.Data.Data.Models.TeamEntity", "Team")
                        .WithMany("Memberships")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S3.Player.Api.Data.Data.Models.UserEntity", "User")
                        .WithMany("TeamMemberships")
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.TeamPermissionEntity", b =>
                {
                    b.HasOne("S3.Player.Api.Data.Data.Models.PermissionEntity", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S3.Player.Api.Data.Data.Models.TeamEntity", "Team")
                        .WithMany("Permissions")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.UserEntity", b =>
                {
                    b.HasOne("S3.Player.Api.Data.Data.Models.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("S3.Player.Api.Data.Data.Models.UserPermissionEntity", b =>
                {
                    b.HasOne("S3.Player.Api.Data.Data.Models.PermissionEntity", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S3.Player.Api.Data.Data.Models.UserEntity", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserKey");
                });
#pragma warning restore 612, 618
        }
    }
}


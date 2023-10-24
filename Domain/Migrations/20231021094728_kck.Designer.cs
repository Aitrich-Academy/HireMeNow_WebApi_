﻿// <auto-generated />
using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(DbHireMeNowWebApiContext))]
    [Migration("20231021094728_kck")]
    partial class kck
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.AuthUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthUser");
                });

            modelBuilder.Entity("Domain.Models.CompanyUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Company")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Company");

                    b.ToTable("CompanyUser", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Industry", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Industry", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobCategory", b =>
                {
                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.ToTable("JobCategory", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobPost", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Category")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Company")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Industry")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobLocation")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobSummary")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<Guid>("PostedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("JobLocation");

                    b.HasIndex("PostedBy");

                    b.ToTable("JobPost", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobProviderCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Industry")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LegalName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Location")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Location");

                    b.ToTable("JobProviderCompany", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobResponsibility", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<Guid>("JobPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("JobPost");

                    b.ToTable("JobResponsibility", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobSeeker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobSeekers");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProfileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("JobSeekerProfile", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Qualification", b =>
                {
                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JobPostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JobseekerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasIndex("JobPostId");

                    b.ToTable("Qualification", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Resume", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Resume", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Role", b =>
                {
                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Domain.Models.SignUpRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SignUpRequests");
                });

            modelBuilder.Entity("Domain.Models.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("JobPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("JobPost");

                    b.ToTable("Skill", (string)null);
                });

            modelBuilder.Entity("Domain.Models.WorkExperience", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobSeekerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ServiceEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ServiceStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Experiences");

                    b.HasIndex("JobSeekerProfileId");

                    b.ToTable("WorkExperience", (string)null);
                });

            modelBuilder.Entity("Domain.Models.CompanyUser", b =>
                {
                    b.HasOne("Domain.Models.JobProviderCompany", "CompanyNavigation")
                        .WithMany("CompanyUsers")
                        .HasForeignKey("Company")
                        .HasConstraintName("FK_CompanyUser_JobProviderCompany");

                    b.Navigation("CompanyNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobPost", b =>
                {
                    b.HasOne("Domain.Models.Location", "JobLocationNavigation")
                        .WithMany("JobPosts")
                        .HasForeignKey("JobLocation")
                        .IsRequired()
                        .HasConstraintName("FK_JobPost_Location");

                    b.HasOne("Domain.Models.CompanyUser", "PostedByNavigation")
                        .WithMany("JobPosts")
                        .HasForeignKey("PostedBy")
                        .IsRequired()
                        .HasConstraintName("FK_JobPost_Industry");

                    b.Navigation("JobLocationNavigation");

                    b.Navigation("PostedByNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobProviderCompany", b =>
                {
                    b.HasOne("Domain.Models.Location", "LocationNavigation")
                        .WithMany("JobProviderCompanies")
                        .HasForeignKey("Location")
                        .IsRequired()
                        .HasConstraintName("FK_JobProviderCompany_Location");

                    b.Navigation("LocationNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobResponsibility", b =>
                {
                    b.HasOne("Domain.Models.JobPost", "JobPostNavigation")
                        .WithMany("JobResponsibilities")
                        .HasForeignKey("JobPost")
                        .IsRequired()
                        .HasConstraintName("FK_JobResponsibility_JobPost");

                    b.Navigation("JobPostNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfile", b =>
                {
                    b.HasOne("Domain.Models.Resume", "Resume")
                        .WithMany("JobSeekerProfiles")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("Domain.Models.Qualification", b =>
                {
                    b.HasOne("Domain.Models.JobPost", "JobPost")
                        .WithMany()
                        .HasForeignKey("JobPostId")
                        .HasConstraintName("FK_Qualification_JobSeekerProfile");

                    b.Navigation("JobPost");
                });

            modelBuilder.Entity("Domain.Models.Skill", b =>
                {
                    b.HasOne("Domain.Models.JobSeekerProfile", null)
                        .WithMany("Skills")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.JobPost", "JobPostNavigation")
                        .WithMany("Skills")
                        .HasForeignKey("JobPost")
                        .IsRequired()
                        .HasConstraintName("FK_Skill_JobSeekerProfile1");

                    b.Navigation("JobPostNavigation");
                });

            modelBuilder.Entity("Domain.Models.WorkExperience", b =>
                {
                    b.HasOne("Domain.Models.JobSeekerProfile", "JobSeekerProfile")
                        .WithMany("WorkExperiences")
                        .HasForeignKey("JobSeekerProfileId")
                        .IsRequired()
                        .HasConstraintName("FK_WorkExperience_JobSeekerProfile");

                    b.Navigation("JobSeekerProfile");
                });

            modelBuilder.Entity("Domain.Models.CompanyUser", b =>
                {
                    b.Navigation("JobPosts");
                });

            modelBuilder.Entity("Domain.Models.JobPost", b =>
                {
                    b.Navigation("JobResponsibilities");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Domain.Models.JobProviderCompany", b =>
                {
                    b.Navigation("CompanyUsers");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfile", b =>
                {
                    b.Navigation("Skills");

                    b.Navigation("WorkExperiences");
                });

            modelBuilder.Entity("Domain.Models.Location", b =>
                {
                    b.Navigation("JobPosts");

                    b.Navigation("JobProviderCompanies");
                });

            modelBuilder.Entity("Domain.Models.Resume", b =>
                {
                    b.Navigation("JobSeekerProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}

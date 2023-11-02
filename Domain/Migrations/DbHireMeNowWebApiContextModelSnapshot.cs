
using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(DbHireMeNowWebApiContext))]
    partial class DbHireMeNowWebApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
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

            modelBuilder.Entity("Domain.Models.JobApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Applicant")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datesubmitted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JobPost_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Resume_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeekerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobPost_id");

                    b.HasIndex("Resume_id");

                    b.HasIndex("SeekerId");

                    b.ToTable("JobApplications");
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

                    b.Property<Guid>("IndustryId")
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

                    b.HasIndex("IndustryId");

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

                    b.Property<Guid>("JobSeekerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProfileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JobSeekerId");

                    b.HasIndex("ResumeId");

                    b.ToTable("JobSeekerProfile", (string)null);
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfileSkill", b =>
                {
                    b.Property<Guid>("JobSeekerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JobSeekerProfileId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSeekerProfileSkill");
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("JobPostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JobseekerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("JobPostId");

                    b.HasIndex("JobseekerProfileId");

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

            modelBuilder.Entity("Domain.Models.SavedJob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Job")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SavedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Job");

                    b.HasIndex("SavedBy");

                    b.ToTable("SavedJobs");
                });

            modelBuilder.Entity("Domain.Models.SavedJob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Job")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SavedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Job");

                    b.HasIndex("SavedBy");

                    b.ToTable("SavedJobs");
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

                    b.Property<Guid?>("JobPostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobSeekerProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Skill", (string)null);
                });

            modelBuilder.Entity("Domain.Models.SystemUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

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

                    b.ToTable("SystemUser", (string)null);
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

            modelBuilder.Entity("Domain.Models.AuthUser", b =>
                {
                    b.HasOne("Domain.Models.SystemUser", "IdNavigation")
                        .WithOne("AuthUserIdNavigation")
                        .HasForeignKey("Domain.Models.AuthUser", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.SystemUser", "SystemUser")
                        .WithMany("AuthUserSystemUsers")
                        .HasForeignKey("SystemUserId")
                        .IsRequired();

                    b.Navigation("IdNavigation");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("Domain.Models.CompanyUser", b =>
                {
                    b.HasOne("Domain.Models.JobProviderCompany", "CompanyNavigation")
                        .WithMany("CompanyUsers")
                        .HasForeignKey("Company")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CompanyUser_JobProviderCompany");

                    b.Navigation("CompanyNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobApplication", b =>
                {
                    b.HasOne("Domain.Models.JobPost", "JobPost")
                        .WithMany()
                        .HasForeignKey("JobPost_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Resume", "Resume")
                        .WithMany()
                        .HasForeignKey("Resume_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.JobSeeker", "Seeker")
                        .WithMany()
                        .HasForeignKey("SeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPost");

                    b.Navigation("Resume");

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("Domain.Models.JobApplication", b =>
                {
                    b.HasOne("Domain.Models.JobSeeker", "Seeker")
                        .WithMany()
                        .HasForeignKey("Applicant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.JobPost", "JobPost")
                        .WithMany()
                        .HasForeignKey("JobPost_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Resume", "Resume")
                        .WithMany()
                        .HasForeignKey("Resume_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPost");

                    b.Navigation("Resume");

                    b.Navigation("Seeker");
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
                    b.HasOne("Domain.Models.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Location", "LocationNavigation")
                        .WithMany("JobProviderCompanies")
                        .HasForeignKey("Location")
                        .IsRequired()
                        .HasConstraintName("FK_JobProviderCompany_Location");

                    b.Navigation("Industry");

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

            modelBuilder.Entity("Domain.Models.JobSeeker", b =>
                {
                    b.HasOne("Domain.Models.SystemUser", "IdNavigation")
                        .WithOne("JobSeeker")
                        .HasForeignKey("Domain.Models.JobSeeker", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfile", b =>
                {
                    b.HasOne("Domain.Models.JobSeeker", "JobSeeker")
                        .WithMany()
                        .HasForeignKey("JobSeekerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Resume", "Resume")
                        .WithMany("JobSeekerProfiles")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobSeeker");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfileSkill", b =>
                {
                    b.HasOne("Domain.Models.JobSeekerProfile", "JobSeekerProfile")
                        .WithMany("JobSeekerProfileSkills")
                        .HasForeignKey("JobSeekerProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobSeekerProfile");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Domain.Models.Qualification", b =>
                {
                    b.HasOne("Domain.Models.JobPost", "JobPost")
                        .WithMany()
                        .HasForeignKey("JobPostId")
                        .HasConstraintName("FK_Qualification_JobSeekerProfile");

                    b.HasOne("Domain.Models.JobSeekerProfile", "JobSeekerProfile")
                        .WithMany("Qualifications")
                        .HasForeignKey("JobseekerProfileId");

                    b.Navigation("JobPost");

                    b.Navigation("JobSeekerProfile");
                });

            modelBuilder.Entity("Domain.Models.SavedJob", b =>
                {
                    b.HasOne("Domain.Models.JobPost", "JobPost")
                        .WithMany()
                        .HasForeignKey("Job")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.JobSeeker", "JobSeeker")
                        .WithMany("SavedJobs")
                        .HasForeignKey("SavedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPost");

                    b.Navigation("JobSeeker");
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
                });

            modelBuilder.Entity("Domain.Models.JobProviderCompany", b =>
                {
                    b.Navigation("CompanyUsers");
                });

            modelBuilder.Entity("Domain.Models.JobSeeker", b =>
                {
                    b.Navigation("SavedJobs");
                });

            modelBuilder.Entity("Domain.Models.JobSeekerProfile", b =>
                {
                    b.Navigation("JobSeekerProfileSkills");

                    b.Navigation("Qualifications");

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

            modelBuilder.Entity("Domain.Models.Skill", b =>
                {
                    b.Navigation("JobSeekerProfileSkills");
                });

        }
    }
}

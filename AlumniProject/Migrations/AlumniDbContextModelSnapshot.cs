﻿// <auto-generated />
using System;
using AlumniProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlumniProject.Migrations
{
    [DbContext(typeof(AlumniDbContext))]
    partial class AlumniDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlumniProject.Entity.AccessRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlumniClassId")
                        .HasColumnType("int");

                    b.Property<int>("AlumniId")
                        .HasColumnType("int");

                    b.Property<int>("AlunmniId")
                        .HasColumnType("int");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlumniClassId");

                    b.HasIndex("AlumniId");

                    b.ToTable("AccessRequest");
                });

            modelBuilder.Entity("AlumniProject.Entity.Alumni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Avatar_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImage_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceBookPublicity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceBook_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhonePublicity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alumni");
                });

            modelBuilder.Entity("AlumniProject.Entity.AlumniClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("AlumniClasse");
                });

            modelBuilder.Entity("AlumniProject.Entity.AlumniToClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlumniId")
                        .HasColumnType("int");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumniId");

                    b.HasIndex("ClassId");

                    b.ToTable("AlumniToClass");
                });

            modelBuilder.Entity("AlumniProject.Entity.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlumniId")
                        .HasColumnType("int");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlumniId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("AlumniProject.Entity.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOffline")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublicSchool")
                        .HasColumnType("bit");

                    b.Property<bool>("PublicPartictipant")
                        .HasColumnType("bit");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("HostId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("AlumniProject.Entity.EventParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlumniId")
                        .HasColumnType("int");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumniId");

                    b.HasIndex("EventId");

                    b.ToTable("EventParticipant");
                });

            modelBuilder.Entity("AlumniProject.Entity.Fund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("BackgroundImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TargetBalance")
                        .HasColumnType("int");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Fund");
                });

            modelBuilder.Entity("AlumniProject.Entity.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("SchoolId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId1")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId1");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("AlumniProject.Entity.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlumniId")
                        .HasColumnType("int");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlumniId");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("AlumniProject.Entity.New", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlumniId")
                        .HasColumnType("int");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsPublic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlumniId");

                    b.HasIndex("SchoolId");

                    b.ToTable("New");
                });

            modelBuilder.Entity("AlumniProject.Entity.NewsTagNew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int>("NewsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("TagsId");

                    b.ToTable("NewsTagNew");
                });

            modelBuilder.Entity("AlumniProject.Entity.Post", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("AlumniId")
                        .HasColumnType("int");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublicSchool")
                        .HasColumnType("bit");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AlumniId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("AlumniProject.Entity.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("BackGround1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackGround2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackGround3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EvidenceUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RequestStatus")
                        .HasColumnType("bit");

                    b.Property<string>("SubDomain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("School");
                });

            modelBuilder.Entity("AlumniProject.Entity.TagsNew", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<string>("tagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TagsNew");
                });

            modelBuilder.Entity("AlumniProject.Entity.AccessRequest", b =>
                {
                    b.HasOne("AlumniProject.Entity.AlumniClass", "AlumniClass")
                        .WithMany()
                        .HasForeignKey("AlumniClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniProject.Entity.Alumni", "Alumni")
                        .WithMany()
                        .HasForeignKey("AlumniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumni");

                    b.Navigation("AlumniClass");
                });

            modelBuilder.Entity("AlumniProject.Entity.AlumniClass", b =>
                {
                    b.HasOne("AlumniProject.Entity.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("AlumniProject.Entity.AlumniToClass", b =>
                {
                    b.HasOne("AlumniProject.Entity.Alumni", "Alumni")
                        .WithMany("AlumniToClasse")
                        .HasForeignKey("AlumniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniProject.Entity.AlumniClass", "Class")
                        .WithMany("AlumniToClasse")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumni");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("AlumniProject.Entity.Education", b =>
                {
                    b.HasOne("AlumniProject.Entity.Alumni", "Alumni")
                        .WithMany("Education")
                        .HasForeignKey("AlumniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumni");
                });

            modelBuilder.Entity("AlumniProject.Entity.Event", b =>
                {
                    b.HasOne("AlumniProject.Entity.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniProject.Entity.Alumni", "Host")
                        .WithMany("Events")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniProject.Entity.School", null)
                        .WithMany("Event")
                        .HasForeignKey("SchoolId");

                    b.Navigation("Grade");

                    b.Navigation("Host");
                });

            modelBuilder.Entity("AlumniProject.Entity.EventParticipant", b =>
                {
                    b.HasOne("AlumniProject.Entity.Alumni", "Alumni")
                        .WithMany("EventParticipants")
                        .HasForeignKey("AlumniId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AlumniProject.Entity.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumni");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("AlumniProject.Entity.Fund", b =>
                {
                    b.HasOne("AlumniProject.Entity.School", "School")
                        .WithMany("Fund")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("AlumniProject.Entity.Grade", b =>
                {
                    b.HasOne("AlumniProject.Entity.School", "School")
                        .WithMany("Grade")
                        .HasForeignKey("SchoolId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("AlumniProject.Entity.Major", b =>
                {
                    b.HasOne("AlumniProject.Entity.Alumni", "Alumni")
                        .WithMany("Major")
                        .HasForeignKey("AlumniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumni");
                });

            modelBuilder.Entity("AlumniProject.Entity.New", b =>
                {
                    b.HasOne("AlumniProject.Entity.Alumni", "Alumni")
                        .WithMany()
                        .HasForeignKey("AlumniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniProject.Entity.School", "School")
                        .WithMany("New")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumni");

                    b.Navigation("School");
                });

            modelBuilder.Entity("AlumniProject.Entity.NewsTagNew", b =>
                {
                    b.HasOne("AlumniProject.Entity.New", "News")
                        .WithMany("NewsTagNews")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniProject.Entity.TagsNew", "Tags")
                        .WithMany("NewsTagNews")
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("AlumniProject.Entity.Post", b =>
                {
                    b.HasOne("AlumniProject.Entity.Alumni", "Alumni")
                        .WithMany()
                        .HasForeignKey("AlumniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniProject.Entity.School", null)
                        .WithMany("Post")
                        .HasForeignKey("SchoolId");

                    b.Navigation("Alumni");
                });

            modelBuilder.Entity("AlumniProject.Entity.Alumni", b =>
                {
                    b.Navigation("AlumniToClasse");

                    b.Navigation("Education");

                    b.Navigation("EventParticipants");

                    b.Navigation("Events");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("AlumniProject.Entity.AlumniClass", b =>
                {
                    b.Navigation("AlumniToClasse");
                });

            modelBuilder.Entity("AlumniProject.Entity.Event", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("AlumniProject.Entity.New", b =>
                {
                    b.Navigation("NewsTagNews");
                });

            modelBuilder.Entity("AlumniProject.Entity.School", b =>
                {
                    b.Navigation("Event");

                    b.Navigation("Fund");

                    b.Navigation("Grade");

                    b.Navigation("New");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("AlumniProject.Entity.TagsNew", b =>
                {
                    b.Navigation("NewsTagNews");
                });
#pragma warning restore 612, 618
        }
    }
}

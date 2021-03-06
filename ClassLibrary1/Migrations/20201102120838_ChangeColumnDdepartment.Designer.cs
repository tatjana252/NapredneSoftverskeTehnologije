﻿// <auto-generated />
using Departments.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Departments.Migrations
{
    [DbContext(typeof(DepartmentsContext))]
    [Migration("20201102120838_ChangeColumnDdepartment")]
    partial class ChangeColumnDdepartment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnrollmentYear")
                        .HasColumnType("int");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.StudentSubject", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("Domain.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Domain.StudentSubject", b =>
                {
                    b.HasOne("Domain.Student", "Student")
                        .WithMany("Subjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Subject", "Subject")
                        .WithMany("Students")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Subject", b =>
                {
                    b.HasOne("Domain.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Domain.SubjectItem", "Items", b1 =>
                        {
                            b1.Property<int>("SubjectId")
                                .HasColumnType("int");

                            b1.Property<int>("SubjectItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SubjectId", "SubjectItemId");

                            b1.ToTable("SubjectItem");

                            b1.WithOwner()
                                .HasForeignKey("SubjectId");

                            b1.OwnsOne("Domain.Content", "Content", b2 =>
                                {
                                    b2.Property<int>("SubjectItemSubjectId")
                                        .HasColumnType("int");

                                    b2.Property<int>("SubjectItemId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<int>("ContentId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Name")
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("SubjectItemSubjectId", "SubjectItemId");

                                    b2.ToTable("SubjectItem");

                                    b2.WithOwner()
                                        .HasForeignKey("SubjectItemSubjectId", "SubjectItemId");
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

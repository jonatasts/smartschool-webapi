﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using smartschool_webapi.Data;

#nullable disable

namespace smartschoolwebapi.Migrations
{
    [DbContext(typeof(SmartSchoolContext))]
    partial class SmartSchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("smartschool_webapi.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Disciplines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Matemática",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Física",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Português",
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Inglês",
                            TeacherId = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "Programação",
                            TeacherId = 5
                        });
                });

            modelBuilder.Entity("smartschool_webapi.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastName = "Kent",
                            Name = "Marta",
                            Number = "33225555"
                        },
                        new
                        {
                            Id = 2,
                            LastName = "Isabela",
                            Name = "Paula",
                            Number = "3354288"
                        },
                        new
                        {
                            Id = 3,
                            LastName = "Antonia",
                            Name = "Laura",
                            Number = "55668899"
                        },
                        new
                        {
                            Id = 4,
                            LastName = "Maria",
                            Name = "Luiza",
                            Number = "6565659"
                        },
                        new
                        {
                            Id = 5,
                            LastName = "Machado",
                            Name = "Lucas",
                            Number = "565685415"
                        },
                        new
                        {
                            Id = 6,
                            LastName = "Alvares",
                            Name = "Pedro",
                            Number = "456454545"
                        },
                        new
                        {
                            Id = 7,
                            LastName = "José",
                            Name = "Paulo",
                            Number = "9874512"
                        });
                });

            modelBuilder.Entity("smartschool_webapi.Models.StudentDiscipline", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "DisciplineId");

                    b.HasIndex("TeacherId");

                    b.ToTable("StudentsDisciplines");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            DisciplineId = 2
                        },
                        new
                        {
                            StudentId = 1,
                            DisciplineId = 4
                        },
                        new
                        {
                            StudentId = 1,
                            DisciplineId = 5
                        },
                        new
                        {
                            StudentId = 2,
                            DisciplineId = 1
                        },
                        new
                        {
                            StudentId = 2,
                            DisciplineId = 2
                        },
                        new
                        {
                            StudentId = 2,
                            DisciplineId = 5
                        },
                        new
                        {
                            StudentId = 3,
                            DisciplineId = 1
                        },
                        new
                        {
                            StudentId = 3,
                            DisciplineId = 2
                        },
                        new
                        {
                            StudentId = 3,
                            DisciplineId = 3
                        },
                        new
                        {
                            StudentId = 4,
                            DisciplineId = 1
                        },
                        new
                        {
                            StudentId = 4,
                            DisciplineId = 4
                        },
                        new
                        {
                            StudentId = 4,
                            DisciplineId = 5
                        },
                        new
                        {
                            StudentId = 5,
                            DisciplineId = 4
                        },
                        new
                        {
                            StudentId = 5,
                            DisciplineId = 5
                        },
                        new
                        {
                            StudentId = 6,
                            DisciplineId = 1
                        },
                        new
                        {
                            StudentId = 6,
                            DisciplineId = 2
                        },
                        new
                        {
                            StudentId = 6,
                            DisciplineId = 3
                        },
                        new
                        {
                            StudentId = 6,
                            DisciplineId = 4
                        },
                        new
                        {
                            StudentId = 7,
                            DisciplineId = 1
                        },
                        new
                        {
                            StudentId = 7,
                            DisciplineId = 2
                        },
                        new
                        {
                            StudentId = 7,
                            DisciplineId = 3
                        },
                        new
                        {
                            StudentId = 7,
                            DisciplineId = 4
                        },
                        new
                        {
                            StudentId = 7,
                            DisciplineId = 5
                        });
                });

            modelBuilder.Entity("smartschool_webapi.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lauro"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Roberto"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ronaldo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rodrigo"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Alexandre"
                        });
                });

            modelBuilder.Entity("smartschool_webapi.Models.Discipline", b =>
                {
                    b.HasOne("smartschool_webapi.Models.Teacher", "Teacher")
                        .WithMany("Disciplines")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("smartschool_webapi.Models.StudentDiscipline", b =>
                {
                    b.HasOne("smartschool_webapi.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("smartschool_webapi.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("smartschool_webapi.Models.Teacher", b =>
                {
                    b.Navigation("Disciplines");
                });
#pragma warning restore 612, 618
        }
    }
}

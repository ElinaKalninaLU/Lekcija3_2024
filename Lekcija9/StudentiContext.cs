using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Lekcija9;

public partial class StudentiContext : DbContext
{
    public StudentiContext()
    {
    }

    public StudentiContext(DbContextOptions<StudentiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseTeacher> CourseTeachers { get; set; }

    public virtual DbSet<Examination> Examinations { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Studenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    {
        string cs = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        optionsBuilder.UseSqlServer(cs);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Attendance");

            entity.Property(e => e.Attendance1)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("Attendance");
            entity.Property(e => e.LectureId).HasColumnName("Lecture_ID");
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");

            entity.HasOne(d => d.Lecture).WithMany()
                .HasForeignKey(d => d.LectureId)
                .HasConstraintName("FK_Attendance_Lecture");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Attendance_Student");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CourseTeacher>(entity =>
        {
            entity.ToTable("Course_teacher");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_date");
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseTeachers)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Course_teacher_Course");

            entity.HasOne(d => d.Teacher).WithMany(p => p.CourseTeachers)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_Course_teacher_Teacher");
        });

        modelBuilder.Entity<Examination>(entity =>
        {
            entity.ToTable("Examination");

            entity.Property(e => e.ExaminationId)
                .ValueGeneratedNever()
                .HasColumnName("Examination_ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.ResponsibleTeacherId).HasColumnName("Responsible_teacher_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.Examinations)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Examination_Course");

            entity.HasOne(d => d.ResponsibleTeacher).WithMany(p => p.Examinations)
                .HasForeignKey(d => d.ResponsibleTeacherId)
                .HasConstraintName("FK_Examination_Teacher");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Grade");

            entity.Property(e => e.ExaminationId).HasColumnName("Examination_ID");
            entity.Property(e => e.Grade1).HasColumnName("Grade");
            entity.Property(e => e.GradingTeacherId).HasColumnName("Grading_teacher_ID");
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");

            entity.HasOne(d => d.Examination).WithMany()
                .HasForeignKey(d => d.ExaminationId)
                .HasConstraintName("FK_Grade_Examination");

            entity.HasOne(d => d.GradingTeacher).WithMany()
                .HasForeignKey(d => d.GradingTeacherId)
                .HasConstraintName("FK_Grade_Teacher");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Grade_Student");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.ToTable("Lecture");

            entity.Property(e => e.LectureId)
                .ValueGeneratedNever()
                .HasColumnName("Lecture_ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.Day).HasColumnType("datetime");
            entity.Property(e => e.Room)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_ID");
            entity.Property(e => e.Time)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Course).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Lecture_Course");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_Lecture_Teacher");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_[Student_course");

            entity.ToTable("Student_course");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.StudentId).HasColumnName("Student_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Student_course_Course");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Student_course_Student");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId).HasColumnName("Teacher_ID");
            entity.Property(e => e.MentorId).HasColumnName("Mentor_ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Mentor).WithMany(p => p.InverseMentor)
                .HasForeignKey(d => d.MentorId)
                .HasConstraintName("FK_Teacher_Teacher");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

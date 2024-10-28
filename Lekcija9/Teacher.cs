using System;
using System.Collections.Generic;

namespace Lekcija9;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? MentorId { get; set; }

    public virtual ICollection<CourseTeacher> CourseTeachers { get; set; } = new List<CourseTeacher>();

    public virtual ICollection<Examination> Examinations { get; set; } = new List<Examination>();

    public virtual ICollection<Teacher> InverseMentor { get; set; } = new List<Teacher>();

    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    public virtual Teacher? Mentor { get; set; }
}

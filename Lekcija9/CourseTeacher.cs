using System;
using System.Collections.Generic;

namespace Lekcija9;

public partial class CourseTeacher
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public int? TeacherId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Teacher? Teacher { get; set; }
}

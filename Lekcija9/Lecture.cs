using System;
using System.Collections.Generic;

namespace Lekcija9;

public partial class Lecture
{
    public int LectureId { get; set; }

    public string? Room { get; set; }

    public DateTime? Day { get; set; }

    public string? Time { get; set; }

    public int? CourseId { get; set; }

    public int? TeacherId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Teacher? Teacher { get; set; }
}

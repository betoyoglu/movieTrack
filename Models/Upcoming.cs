using System;
using System.Collections.Generic;

namespace WebProject.Models;

public partial class Upcoming
{
    public int Id { get; set; }

    public string? SeriesName { get; set; }

    public int? Season { get; set; }

    public int? Episode { get; set; }

    public int? DurationTime { get; set; }

    public DateTime ReleaseDate { get; set; }
}

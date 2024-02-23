using System;
using System.Collections.Generic;

namespace WebProject.Models;

public partial class MovieNameDirector
{
    public int Id { get; set; }

    public string? MovieName { get; set; }

    public string? MovieDirector { get; set; }
}

using System;
using System.Collections.Generic;

namespace WebProject.Models;

public partial class Anime
{
    public int Id { get; set; }

    public string? AnimeName { get; set; }

    public string? AnimeCategory { get; set; }

    public DateTime? AnimeReleaseDate { get; set; }
}

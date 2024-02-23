using System;
using System.Collections.Generic;

namespace WebProject.Models;

public partial class WatchList
{
    public int Id { get; set; }

    public string Name { get; set; } 

    public string Did_you_watch_it { get; set; } 

    public DateTime Date { get; set; } = DateTime.Now;
}

using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Race
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Warband> Warbands { get; set; } = new List<Warband>();
}

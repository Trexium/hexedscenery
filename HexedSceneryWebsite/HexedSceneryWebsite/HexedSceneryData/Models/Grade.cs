using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<HiredSword> HiredSwords { get; set; } = new List<HiredSword>();
}

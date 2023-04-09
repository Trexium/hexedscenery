using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Warband
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<HiredSwordCompatibleWarband> HiredSwordCompatibleWarbands { get; } = new List<HiredSwordCompatibleWarband>();
}

using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Warband
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? RaceId { get; set; }

    public virtual ICollection<HiredSwordCompatibleWarband> HiredSwordCompatibleWarbands { get; set; } = new List<HiredSwordCompatibleWarband>();

    public virtual Race? Race { get; set; }
}

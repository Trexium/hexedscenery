using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class DiceType
{
    public int Id { get; set; }

    public string DisplayName { get; set; } = null!;

    public int MinNumber { get; set; }

    public int MaxNumber { get; set; }

    public virtual ICollection<EncounterType> EncounterTypes { get; set; } = new List<EncounterType>();
}

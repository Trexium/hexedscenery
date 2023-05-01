using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class EncounterType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Encounter> Encounters { get; } = new List<Encounter>();
}

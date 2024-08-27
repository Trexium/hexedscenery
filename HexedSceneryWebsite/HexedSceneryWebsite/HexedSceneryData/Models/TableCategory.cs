using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class TableCategory
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<EncounterType> EncounterTypes { get; set; } = new List<EncounterType>();
}

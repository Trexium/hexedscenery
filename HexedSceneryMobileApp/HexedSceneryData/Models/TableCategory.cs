using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class TableCategory
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public bool? Active { get; set; }

    public List<EncounterType>? EncounterTypes { get; set; }
}

using System;
using System.Collections.Generic;

namespace HexedSceneryMobileApp.ApiModels;

public class TableCategory
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public bool? Active { get; set; }

    public ICollection<EncounterType>? EncounterTypes { get; set; }
}

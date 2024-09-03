using System;
using System.Collections.Generic;

namespace HexedSceneryMobileApp.ApiModels;

public class DiceType
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public int MinNumber { get; set; }

    public int MaxNumber { get; set; }

    public List<EncounterType>? EncounterTypes { get; set; }
}

using System;
using System.Collections.Generic;

namespace HexedSceneryApiClient.Models;

public class Encounter
{
    public int Id { get; set; }

    public int ResultNumber { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? BottomText { get; set; }

    public int? MonsterId { get; set; }

    public int? DiceChartId { get; set; }

    public int EncounterTypeId { get; set; }

    public DiceChart? DiceChart { get; set; }

    public EncounterType? EncounterType { get; set; }

    public Monster? Monster { get; set; }
}

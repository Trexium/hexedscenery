using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Encounter
{
    public int Id { get; set; }

    public int ResultNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? BottomText { get; set; }

    public int? MonsterId { get; set; }

    public int? DiceChartId { get; set; }

    public int EncounterTypeId { get; set; }

    public virtual DiceChart? DiceChart { get; set; }

    public virtual EncounterType EncounterType { get; set; } = null!;

    public virtual Monster? Monster { get; set; }
}

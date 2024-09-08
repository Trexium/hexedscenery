using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class EncounterType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? DisplayName { get; set; }

    public int TableCategoryId { get; set; }

    public int? DiceTypeId { get; set; }

    public int? NumberOfDice { get; set; }

    public bool? Active { get; set; }

    public string? Description { get; set; }

    public virtual DiceType? DiceType { get; set; }

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual TableCategory TableCategory { get; set; } = null!;
}

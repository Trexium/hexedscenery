using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class DiceChart
{
    public int Id { get; set; }

    public string? Dice { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int MinNumber { get; set; }

    public int MaxNumber { get; set; }

    public int? DiceTypeId { get; set; }

    public int? NumberOfDice { get; set; }

    public virtual ICollection<DiceResult> DiceResults { get; set; } = new List<DiceResult>();

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();
}

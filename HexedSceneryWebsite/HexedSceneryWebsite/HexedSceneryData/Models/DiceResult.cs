using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class DiceResult
{
    public int Id { get; set; }

    public int ResultNumber { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int DiceChartId { get; set; }

    public virtual DiceChart DiceChart { get; set; } = null!;
}

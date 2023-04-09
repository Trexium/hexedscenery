using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class MonsterSpecialRule
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int SpecialRuleId { get; set; }

    public virtual Monster Monster { get; set; } = null!;

    public virtual SpecialRule SpecialRule { get; set; } = null!;
}

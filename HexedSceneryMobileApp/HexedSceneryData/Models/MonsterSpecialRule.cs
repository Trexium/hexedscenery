using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class MonsterSpecialRule
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int SpecialRuleId { get; set; }

    public Monster? Monster { get; set; }

    public SpecialRule? SpecialRule { get; set; }
}

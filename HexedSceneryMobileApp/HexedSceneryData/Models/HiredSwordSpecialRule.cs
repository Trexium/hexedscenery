using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class HiredSwordSpecialRule
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? SpecialRuleId { get; set; }

    public HiredSword? HiredSword { get; set; }

    public SpecialRule? SpecialRule { get; set; }
}

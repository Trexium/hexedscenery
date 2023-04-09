using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class HiredSwordSpecialRule
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? SpecialRuleId { get; set; }

    public virtual HiredSword? HiredSword { get; set; }

    public virtual SpecialRule? SpecialRule { get; set; }
}

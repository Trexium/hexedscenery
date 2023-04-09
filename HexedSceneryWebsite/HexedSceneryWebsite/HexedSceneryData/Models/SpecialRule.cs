﻿using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class SpecialRule
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<HiredSwordSpecialRule> HiredSwordSpecialRules { get; } = new List<HiredSwordSpecialRule>();

    public virtual ICollection<MonsterSpecialRule> MonsterSpecialRules { get; } = new List<MonsterSpecialRule>();
}

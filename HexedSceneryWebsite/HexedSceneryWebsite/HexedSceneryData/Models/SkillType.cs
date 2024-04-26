using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class SkillType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<HiredSwordSkillType> HiredSwordSkillTypes { get; set; } = new List<HiredSwordSkillType>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}

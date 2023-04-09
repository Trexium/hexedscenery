using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class SkillType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}

using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class MonsterSkill
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int SkillId { get; set; }

    public virtual Monster Monster { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}

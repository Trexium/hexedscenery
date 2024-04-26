using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int SkillTypeId { get; set; }

    public virtual ICollection<HiredSwordSkill> HiredSwordSkills { get; set; } = new List<HiredSwordSkill>();

    public virtual ICollection<MonsterSkill> MonsterSkills { get; set; } = new List<MonsterSkill>();

    public virtual SkillType SkillType { get; set; } = null!;
}

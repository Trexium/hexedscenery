using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class Skill
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int SkillTypeId { get; set; }

    public List<HiredSwordSkill>? HiredSwordSkills { get; set; }

    public List<MonsterSkill>? MonsterSkills { get; set; }

    public SkillType? SkillType { get; set; }
}

using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class SkillType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<HiredSwordSkillType>? HiredSwordSkillTypes { get; set; }

    public List<Skill>? Skills { get; set; }
}

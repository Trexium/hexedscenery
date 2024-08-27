using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class MonsterSkill
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int SkillId { get; set; }

    public Monster? Monster { get; set; }

    public Skill? Skill { get; set; }
}

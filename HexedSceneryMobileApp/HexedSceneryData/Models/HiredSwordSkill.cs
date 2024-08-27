using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class HiredSwordSkill
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? SkillId { get; set; }

    public HiredSword? HiredSword { get; set; }

    public Skill? Skill { get; set; }
}

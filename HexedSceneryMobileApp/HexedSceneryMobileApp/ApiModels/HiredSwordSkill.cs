using System;
using System.Collections.Generic;

namespace HexedSceneryMobileApp.ApiModels;

public class HiredSwordSkill
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? SkillId { get; set; }

    public HiredSword? HiredSword { get; set; }

    public Skill? Skill { get; set; }
}

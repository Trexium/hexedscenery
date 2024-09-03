using System;
using System.Collections.Generic;

namespace HexedSceneryMobileApp.ApiModels;

public class HiredSwordSkillType
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? SkillTypeId { get; set; }

    public HiredSword? HiredSword { get; set; }

    public SkillType? SkillType { get; set; }
}

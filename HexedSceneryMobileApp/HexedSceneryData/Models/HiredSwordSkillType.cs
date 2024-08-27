using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class HiredSwordSkillType
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? SkillTypeId { get; set; }

    public HiredSword? HiredSword { get; set; }

    public SkillType? SkillType { get; set; }
}

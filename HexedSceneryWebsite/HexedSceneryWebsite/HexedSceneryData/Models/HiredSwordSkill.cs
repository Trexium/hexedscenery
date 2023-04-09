using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class HiredSwordSkill
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? SkillId { get; set; }

    public virtual HiredSword? HiredSword { get; set; }

    public virtual Skill? Skill { get; set; }
}

using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class HiredSwordSkillType
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? SkillTypeId { get; set; }

    public virtual HiredSword? HiredSword { get; set; }

    public virtual SkillType? SkillType { get; set; }
}

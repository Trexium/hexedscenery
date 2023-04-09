using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class HiredSwordCompatibleWarband
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? WarbandId { get; set; }

    public virtual HiredSword? HiredSword { get; set; }

    public virtual Warband? Warband { get; set; }
}

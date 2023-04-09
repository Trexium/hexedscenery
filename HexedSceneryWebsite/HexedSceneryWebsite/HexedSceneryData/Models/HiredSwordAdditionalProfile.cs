using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class HiredSwordAdditionalProfile
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? ProfileId { get; set; }

    public virtual HiredSword? HiredSword { get; set; }

    public virtual Profile? Profile { get; set; }
}

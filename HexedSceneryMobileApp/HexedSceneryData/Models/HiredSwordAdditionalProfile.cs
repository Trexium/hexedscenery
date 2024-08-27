using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class HiredSwordAdditionalProfile
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? ProfileId { get; set; }

    public HiredSword? HiredSword { get; set; }

    public Profile? Profile { get; set; }
}

using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class HiredSwordEquipment
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? EquipmentId { get; set; }

    public virtual Equipment? Equipment { get; set; }

    public virtual HiredSword? HiredSword { get; set; }
}

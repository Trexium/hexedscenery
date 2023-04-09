using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<HiredSwordEquipment> HiredSwordEquipments { get; } = new List<HiredSwordEquipment>();
}

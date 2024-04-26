using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<HiredSwordEquipment> HiredSwordEquipments { get; set; } = new List<HiredSwordEquipment>();

    public virtual ICollection<MonsterEquipment> MonsterEquipments { get; set; } = new List<MonsterEquipment>();
}

using System;
using System.Collections.Generic;

namespace HexedSceneryData.Models;

public class MonsterEquipment
{
    public int Id { get; set; }

    public int MonsterId { get; set; }

    public int EquipmentId { get; set; }

    public Equipment? Equipment { get; set; }

    public Monster? Monster { get; set; }
}

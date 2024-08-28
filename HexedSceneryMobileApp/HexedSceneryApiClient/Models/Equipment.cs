using System;
using System.Collections.Generic;

namespace HexedSceneryApiClient.Models;

public class Equipment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<HiredSwordEquipment>? HiredSwordEquipments { get; set; }

    public List<MonsterEquipment>? MonsterEquipments { get; set; }
}

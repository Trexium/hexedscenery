using System;
using System.Collections.Generic;

namespace HexedSceneryMobileApp.ApiModels;

public class HiredSwordEquipment
{
    public int Id { get; set; }

    public int? HiredSwordId { get; set; }

    public int? EquipmentId { get; set; }

    public Equipment? Equipment { get; set; }

    public HiredSword? HiredSword { get; set; }
}

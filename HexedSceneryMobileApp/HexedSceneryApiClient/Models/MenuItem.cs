﻿namespace HexedSceneryApiClient.Models
{
    public enum MenuItemTypeEnum
    {
        HiredSwords = 0,
        EncounterType = 1,

    }
    public class MenuItem
    {
        public int? Id { get; set; }
        public string DisplayText { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public MenuItemTypeEnum Type { get; set; }
    }
}

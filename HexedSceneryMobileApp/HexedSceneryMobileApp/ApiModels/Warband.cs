﻿
namespace HexedSceneryMobileApp.ApiModels
{
    public class Warband
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? RaceId { get; set; }
        public Race? Race { get; set; }
        public IEnumerable<HiredSword> CompatibleHiredSwords { get; set; }
    }
}
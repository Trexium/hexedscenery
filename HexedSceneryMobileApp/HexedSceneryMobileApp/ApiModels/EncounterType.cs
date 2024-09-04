﻿
namespace HexedSceneryMobileApp.ApiModels
{
    public class EncounterType
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? DisplayName { get; set; }

        public int TableCategoryId { get; set; }

        public int? DiceTypeId { get; set; }

        public int? NumberOfDice { get; set; }

        public bool? Active { get; set; }

        public DiceType? DiceType { get; set; }
    }
}

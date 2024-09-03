namespace HexedSceneryWebsite.Api.v1.Models
{
    public class HiredSword
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int HireFee { get; set; }
        public string? HireFeeDescription { get; set; }
        public int UpkeepCost { get; set; }
        public string? UpkeepCostDescription { get; set; }
        public string? CompatabilityDescription { get; set; }
        public int ProfileId { get; set; }
        public int GradeId { get; set; }
        public int SourceId { get; set; }
        public string? Rating { get; set; }
        public bool Active { get; set; }
        public Grade? Grade { get; set; }
        public IEnumerable<Profile>? AdditionalProfiles { get; set; }
        public IEnumerable<Warband>? CompatibleWarbands { get; set; }
        public IEnumerable<Equipment>? Equipment { get; set; }
        public IEnumerable<SkillType>? SkillTypes { get; set; }
        public IEnumerable<Skill>? Skills { get; set; }
        public IEnumerable<SpecialRule>? SpecialRules { get; set; }
        public Profile? Profile { get; set; }
        public Source? Source { get; set; }
    }
}

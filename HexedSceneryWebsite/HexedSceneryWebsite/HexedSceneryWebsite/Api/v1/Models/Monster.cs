namespace HexedSceneryWebsite.Api.v1.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ProfileId { get; set; }
        public IEnumerable<Profile>? AdditionalProfiles { get; set; }
        public IEnumerable<Equipment>? Equipment { get; set; }
        public IEnumerable<Skill>? Skills { get; set; }
        public IEnumerable<SpecialRule>? SpecialRules { get; set; }
        public Profile? Profile { get; set; }
    }
}

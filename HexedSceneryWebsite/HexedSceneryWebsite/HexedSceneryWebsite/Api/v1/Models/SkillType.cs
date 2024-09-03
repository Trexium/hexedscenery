namespace HexedSceneryWebsite.Api.v1.Models
{
    public class SkillType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Skill>? Skills { get; set; }
    }
}

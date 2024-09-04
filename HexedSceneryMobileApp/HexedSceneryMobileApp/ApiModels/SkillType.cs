namespace HexedSceneryMobileApp.ApiModels
{
    public class SkillType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Skill>? Skills { get; set; }
    }
}

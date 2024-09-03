namespace HexedSceneryWebsite.Api.v1.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Movement { get; set; }

        public string? WeaponSkill { get; set; }

        public string? BallisticSkill { get; set; }

        public string? Strength { get; set; }

        public string? Toughness { get; set; }

        public string? Wounds { get; set; }

        public string? Initiative { get; set; }

        public string? Attacks { get; set; }

        public string? Leadership { get; set; }
    }
}

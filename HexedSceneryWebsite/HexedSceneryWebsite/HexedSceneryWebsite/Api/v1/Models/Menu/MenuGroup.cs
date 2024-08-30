namespace HexedSceneryWebsite.Api.v1.Models.Menu
{
    public class MenuGroup
    {
        public string Id { get; set; }
        public string DisplayText { get; set; }
        public List<MenuItem> Items { get; set; }
        public List<MenuGroup> Groups { get; set; }

    }
}

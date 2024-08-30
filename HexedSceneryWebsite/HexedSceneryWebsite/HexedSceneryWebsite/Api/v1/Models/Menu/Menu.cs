namespace HexedSceneryWebsite.Api.v1.Models.Menu
{
    public class Menu
    {
        public string Title { get; set; }
        public List<MenuItem> Items { get; set; }
        public List<MenuGroup> Groups { get; set; }

    }
}

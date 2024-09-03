namespace HexedSceneryMobileApp.ApiModels
{
    public class Menu
    {
        public string Title { get; set; }
        public List<MenuItem> Items { get; set; }
        public List<MenuGroup> Groups { get; set; }

    }
}

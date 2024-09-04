namespace HexedSceneryMobileApp.ApiModels
{
    public class MenuItem
    {
        public int? Id { get; set; }
        public string DisplayText { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public MenuItemTypeEnum Type { get; set; }
    }
}

using Microsoft.AspNetCore.Components.Routing;

namespace HexedSceneryWebsite.Components.Components
{
    public class NavLinkModel
    {
        public NavLinkModel()
        {
            Identifier = Guid.NewGuid();
        }

        public string Url { get; set; }
        public string DisplayName { get; set; }
        public string IconCssClass { get; set; }
        public List<NavLinkModel> Children { get; set; }
        public Guid Identifier { get; set; }
        public bool IsChildrenVisible { get; set; }
        public string SubMenuCssClass => IsChildrenVisible ? "show" : "transition-collapsed";
        public NavLinkMatch? NavLinkMatch { get; set; }
    }
}

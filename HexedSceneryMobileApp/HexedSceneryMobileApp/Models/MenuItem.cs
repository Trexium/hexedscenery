using HexedSceneryMobileApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class MenuItem
    {
        public int? Id { get; set; }
        public string DisplayText { get; set; }
        public string Url { get; set; }
        public MenuItemType Type { get; set; }
    }
}

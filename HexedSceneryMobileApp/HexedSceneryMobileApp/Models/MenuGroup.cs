using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class MenuGroup
    {
        public string Id { get; set; }
        public string DisplayTitle { get; set; }
        public bool Expanded { get; set; }
        public List<MenuItem> Children { get; set; }
    }
}

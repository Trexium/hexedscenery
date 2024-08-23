using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class MenuItem
    {
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public List<MenuItem> Children { get; set; }
    }
}

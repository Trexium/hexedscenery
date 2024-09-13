using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class Warband
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? RaceId { get; set; }
        public Race? Race { get; set; }
        public IEnumerable<int> CompatibleHiredSwordIds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class TableCategory
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public bool? Active { get; set; }
        public List<EncounterType>? EncounterTypes { get; set; }
    }
}

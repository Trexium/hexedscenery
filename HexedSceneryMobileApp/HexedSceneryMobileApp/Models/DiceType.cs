using HexedSceneryMobileApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class DiceType
    {
        public int Id { get; set; }

        public string? DisplayName { get; set; }

        public int MinNumber { get; set; }

        public int MaxNumber { get; set; }
        public Die Type { get; set; }
    }
}

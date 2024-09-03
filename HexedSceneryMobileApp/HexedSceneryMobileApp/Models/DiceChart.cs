﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class DiceChart
    {
        public int Id { get; set; }

        public string? Dice { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int MinNumber { get; set; }

        public int MaxNumber { get; set; }

        public int? DiceTypeId { get; set; }

        public int? NumberOfDice { get; set; }

        public List<DiceResult>? DiceResults { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexedSceneryCommon.Enums;

namespace HexedSceneryCommon.Models
{
    public abstract class TableTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DiceType? DiceType { get; set; }
        public int? NumberOfDice { get; set; }
        public List<TableTypeModel> Children { get; set; }
    }
}

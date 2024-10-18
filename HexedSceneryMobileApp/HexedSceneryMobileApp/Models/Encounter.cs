using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class Encounter
    {
        public int Id { get; set; }

        public int ResultNumber { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? BottomText { get; set; }

        public int? MonsterId { get; set; }

        public int? DiceChartId { get; set; }

        public int EncounterTypeId { get; set; }

        public DiceChart? DiceChart { get; set; }

        public Monster? Monster { get; set; }
        public string? ShortDescription 
        { 
            get 
            {
                if (!string.IsNullOrEmpty(Description) && Description.Length > 20)
                {
                    return $"{Description.Substring(0, 17)}...";
                }
                else
                {
                    return Description;
                }
            } 
        }

        public string? ShortName
        {
            get
            {
                if (!string.IsNullOrEmpty(Name) && Name.Length > 20)
                {
                    return $"{Name.Substring(0, 17)}...";
                }
                else
                {
                    return Name;
                }
            }
        }
    }
}

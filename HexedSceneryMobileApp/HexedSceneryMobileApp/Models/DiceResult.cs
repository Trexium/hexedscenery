
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class DiceResult
    {
        public int Id { get; set; }

        public int ResultNumber { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int DiceChartId { get; set; }

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
    }
}

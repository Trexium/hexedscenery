using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class Roll
    {
        public Roll() 
        { 
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int ResultNumber { get;set; }
        public EncounterType EncounterType { get; set; }
        public Encounter Encounter { get; set; }
        public DiceChart? ChildChart { get; set; }
        public List<DiceResult>? ChildChartResults { get; set; }
        
        //public string Result { get { return $"{ResultNumber} - {ResultName}"; } }
        //public string EffectShort { get
        //    {
        //        if (Effect.Length < 21)
        //        {
        //            ShowFullEffect = true;
        //            return Effect;
        //        }
        //        else
        //        {
        //            return $"{Effect.Substring(0, 17)}...";
        //        }
        //    } }

        //public bool ShowFullEffect { get; set; }
    }
}

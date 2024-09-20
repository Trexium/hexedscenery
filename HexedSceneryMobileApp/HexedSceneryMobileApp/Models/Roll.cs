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
        public string ResultName { get; set; }
        public string TableName { get; set; }
        public string Effect {  get; set; }
        public string Result { get { return $"{ResultNumber} - {ResultName}"; } }
        public string DisplayEffectText { get
            {
                return Effect.Length > 250 ? $"{Effect.Substring(0, 247)}..." : Effect;
            } }
    }
}

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
        public string EffectShort { get
            {
                if (Effect.Length < 101)
                {
                    ShowFullEffect = true;
                    return Effect;
                }
                else
                {
                    return $"{Effect.Substring(0, 97)}...";
                }
            } }

        public bool ShowFullEffect { get; set; }
    }
}

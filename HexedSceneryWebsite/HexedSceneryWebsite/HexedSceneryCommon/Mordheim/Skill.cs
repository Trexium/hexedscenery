﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HexedSceneryCommon.Mordheim
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SkillType Type { get; set; }
    }
}

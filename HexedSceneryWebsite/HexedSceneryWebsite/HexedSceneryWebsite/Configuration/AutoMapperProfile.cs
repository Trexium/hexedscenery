
using AutoMapper;
using Common = HexedSceneryCommon.Mordheim;
using DataModels = HexedSceneryData.Models;

namespace HexedSceneryWebsite.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataModels.DiceResult, Common.DiceResult>()
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.ResultNumber, opt => opt.MapFrom(s => s.ResultNumber));

            CreateMap<DataModels.DiceChart, Common.DiceChart>()
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.Dice, opt => opt.MapFrom(s => s.Dice))
                .ForMember(m => m.DiceResults, opt => opt.MapFrom(s => s.DiceResults))
                .ForMember(m => m.MaxNumber, opt => opt.MapFrom(s => s.MaxNumber))
                .ForMember(m => m.MinNumber, opt => opt.MapFrom(s => s.MinNumber))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name));

            CreateMap<DataModels.Skill, Common.Skill>()
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.Type, opt => opt.MapFrom(s => s.SkillType));

            CreateMap<DataModels.SpecialRule, Common.SpecialRule>()
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name));

            CreateMap<DataModels.Profile, Common.Profile>()
                .ForMember(m => m.Attacks, opt => opt.MapFrom(s => s.Attacks))
                .ForMember(m => m.BallisticSkill, opt => opt.MapFrom(s => s.BallisticSkill))
                .ForMember(m => m.Initiative, opt => opt.MapFrom(s => s.Initiative))
                .ForMember(m => m.Leadership, opt => opt.MapFrom(s => s.Leadership))
                .ForMember(m => m.Movement, opt => opt.MapFrom(s => s.Movement))
                .ForMember(m => m.Strength, opt => opt.MapFrom(s => s.Strength))
                .ForMember(m => m.Toughness, opt => opt.MapFrom(s => s.Toughness))
                .ForMember(m => m.WeaponSkill, opt => opt.MapFrom(s => s.WeaponSkill))
                .ForMember(m => m.Wounds, opt => opt.MapFrom(s => s.Wounds));

            CreateMap<DataModels.Monster, Common.Monster>()
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.Profile, opt => opt.MapFrom(s => s.Profile))
                .ForMember(m => m.AdditionalProfiles, opt => opt.MapFrom(s => s.MonsterAdditionalProfiles.Select(m => m.Profile)))
                .ForMember(m => m.SpecialRules, opt => opt.MapFrom(s => s.MonsterSpecialRules.Select(m => m.SpecialRule)))
                .ForMember(m => m.Skills, opt => opt.MapFrom(s => s.MonsterSkills.Select(m => m.Skill)));

            CreateMap<DataModels.Encounter, Common.Encounter>()
                .ForMember(m => m.BottomText, opt => opt.MapFrom(s => s.BottomText))
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.ResultNumber, opt => opt.MapFrom(s => s.ResultNumber))
                .ForMember(m => m.DiceChart, opt => opt.MapFrom(s => s.DiceChart))
                .ForMember(m => m.Monster, opt => opt.MapFrom(s => s.Monster));
        }
    }
}

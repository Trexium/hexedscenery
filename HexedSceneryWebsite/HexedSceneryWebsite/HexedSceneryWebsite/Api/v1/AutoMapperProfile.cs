using AutoMapper;
using HexedSceneryWebsite.Api.v1.Models;
using Data = HexedSceneryData.Models;
using Profile = HexedSceneryWebsite.Api.v1.Models.Profile;
using System.Linq;

namespace HexedSceneryWebsite.Api.v1
{

    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data.DiceChart, DiceChart>()
                .ForMember(m => m.DiceResults, opt =>
                {
                    opt.PreCondition(m => m.DiceResults != null);
                    opt.MapFrom(s => s.DiceResults.ToList());
                });
            CreateMap<Data.DiceResult, DiceResult>();
            CreateMap<Data.DiceType, DiceType>();
            CreateMap<Data.Encounter, Encounter>();
            CreateMap<Data.EncounterType, EncounterType>();
            CreateMap<Data.Equipment, Equipment>();
            CreateMap<Data.Grade, Grade>();
            CreateMap<Data.HiredSword, HiredSword>()
                .ForMember(m => m.AdditionalProfiles, opt => opt.MapFrom(s => s.HiredSwordAdditionalProfiles))
                .ForMember(m => m.CompatibleWarbands, opt => opt.MapFrom(s => s.HiredSwordCompatibleWarbands))
                .ForMember(m => m.Equipment, opt => opt.MapFrom(s => s.HiredSwordEquipments))
                .ForMember(m => m.SkillTypes, opt => opt.MapFrom(s => s.HiredSwordSkillTypes))
                .ForMember(m => m.Skills, opt => opt.MapFrom(s => s.HiredSwordSkills))
                .ForMember(m => m.SpecialRules, opt => opt.MapFrom(s => s.HiredSwordSpecialRules));
            CreateMap<Data.HiredSwordAdditionalProfile, Profile>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.Profile));
            CreateMap<Data.HiredSwordCompatibleWarband, Warband>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.Warband));
            CreateMap<Data.HiredSwordEquipment, Equipment>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.Equipment));
            CreateMap<Data.HiredSwordSkill, Skill>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.Skill));
            CreateMap<Data.HiredSwordSkillType, SkillType>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.SkillType));
            CreateMap<Data.HiredSwordSpecialRule, SpecialRule>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.SpecialRule));
            CreateMap<Data.Monster, Monster>()
                .ForMember(m => m.Equipment, opt => opt.MapFrom(s => s.MonsterEquipments))
                .ForMember(m => m.Skills, opt => opt.MapFrom(s => s.MonsterSkills))
                .ForMember(m => m.SpecialRules, opt => opt.MapFrom(s => s.MonsterSpecialRules))
                .ForMember(m => m.AdditionalProfiles, opt => opt.MapFrom(s => s.MonsterAdditionalProfiles));
            CreateMap<Data.MonsterAdditionalProfile, Profile>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.Profile));
            CreateMap<Data.MonsterEquipment, Equipment>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.Equipment));
            CreateMap<Data.MonsterSkill, Skill>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.Skill));
            CreateMap<Data.MonsterSpecialRule, SpecialRule>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.SpecialRule));
            CreateMap<Data.Profile, Profile>();
            CreateMap<Data.Race, Race>();
            CreateMap<Data.Skill, Skill>();
            CreateMap<Data.SkillType, SkillType>()
                .ForMember(m => m.Skills, opt =>
                {
                    opt.PreCondition(m => m.Skills != null);
                    opt.MapFrom(s => s.Skills.ToList());
                });
            CreateMap<Data.Source, Source>();
            CreateMap<Data.SpecialRule, SpecialRule>();
            CreateMap<Data.TableCategory, TableCategory>()
                .ForMember(m => m.EncounterTypes, opt =>
                {
                    opt.PreCondition(m => m.EncounterTypes != null);
                    opt.MapFrom(s => s.EncounterTypes.ToList());
                });
            CreateMap<Data.Warband, Warband>()
                .ForMember(m => m.CompatibleHiredSwords, opt =>
                {
                    opt.PreCondition(m => m.HiredSwordCompatibleWarbands != null);
                    opt.MapFrom(s => s.HiredSwordCompatibleWarbands);
                });
            CreateMap<Data.HiredSwordCompatibleWarband, HiredSword>()
                .ForMember(m => m, opt => opt.MapFrom(s => s.HiredSword));
        }

    }
}

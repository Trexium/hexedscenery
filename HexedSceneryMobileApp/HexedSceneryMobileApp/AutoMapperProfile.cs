using AutoMapper;
using HexedSceneryMobileApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApiModels.DiceChart, Models.DiceChart>()
                .ForMember(m => m.DiceResults, opt =>
                {
                    opt.PreCondition(m => m.DiceResults != null);
                    opt.MapFrom(s => s.DiceResults.ToList());
                });

            CreateMap<ApiModels.DiceResult, Models.DiceResult>();

            CreateMap<ApiModels.DiceType, Models.DiceType>()
                .ForMember(m => m.Type, opt => opt.MapFrom(s => (Enums.Die)s.Id));

            CreateMap<ApiModels.Encounter, Models.Encounter>();

            CreateMap<ApiModels.EncounterType, Models.EncounterType>();

            CreateMap<ApiModels.Equipment, Models.Equipment>();

            CreateMap<ApiModels.Monster, Models.Monster>()
                .ForMember(m => m.AdditionalProfiles, opt =>
                {
                    opt.PreCondition(m => m.AdditionalProfiles != null);
                    opt.MapFrom(s => s.AdditionalProfiles.ToList());
                })
                .ForMember(m => m.Equipments, opt =>
                {
                    opt.PreCondition(m => m.Equipment != null);
                    opt.MapFrom(s => s.Equipment.ToList());
                })
                .ForMember(m => m.Skills, opt =>
                {
                    opt.PreCondition(m => m.Skills != null);
                    opt.MapFrom(s => s.Skills.ToList());
                })
                .ForMember(m => m.SpecialRules, opt =>
                {
                    opt.PreCondition(m => m.SpecialRules != null);
                    opt.MapFrom(s => s.SpecialRules.ToList());
                });

            CreateMap<ApiModels.Profile, Models.Profile>();

            CreateMap<ApiModels.Skill, Models.Skill>();

            CreateMap<ApiModels.SkillType, Models.SkillType>()
                .ForMember(m => m.Skills, opt =>
                {
                    opt.PreCondition(m => m.Skills != null);
                    opt.MapFrom(s => s.Skills.ToList());
                });

            CreateMap<ApiModels.SpecialRule, Models.SpecialRule>();

            CreateMap<ApiModels.TableCategory, Models.TableCategory>()
                .ForMember(m => m.EncounterTypes, opt =>
                {
                    opt.PreCondition(m => m.EncounterTypes != null);
                    opt.MapFrom(s => s.EncounterTypes.ToList());
                });

            CreateMap<ApiModels.Menu, Models.Menu>();

            CreateMap<ApiModels.MenuGroup, Models.MenuGroup>();

            CreateMap<ApiModels.MenuItem, Models.MenuItem>()
                .ForMember(m => m.Type, opt => opt.MapFrom(s => (MenuItemType)((int)s.Type)));

        }
    }
}

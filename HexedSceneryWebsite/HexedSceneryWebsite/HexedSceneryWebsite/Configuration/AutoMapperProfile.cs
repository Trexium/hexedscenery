
using AutoMapper;
using Common = HexedSceneryCommon.Mordheim;
using DataModels = HexedSceneryData.Models;
using Main = HexedSceneryCommon.Main;

namespace HexedSceneryWebsite.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            MapCommon();
            MapMain();
            MapEncounter();
            MapWarband();
            MapHiredSword();
        }

        private void MapMain()
        {
            CreateMap<DataModels.Image, Main.Image>()
                .ForMember(m => m.ImagePath, opt => opt.MapFrom(s => s.ImagePath))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Priority, opt => opt.MapFrom(s => s.Priority))
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description));
        }
        private void MapCommon()
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

            CreateMap<DataModels.Grade, Common.Grade>()
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name));

            CreateMap<DataModels.Source, Common.Source>()
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.PdfUrl, opt => opt.MapFrom(s => s.PdfUrl));

            CreateMap<DataModels.Equipment, Common.Equipment>()
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name));

            CreateMap<DataModels.SpecialRule, Common.SpecialRule>()
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description));
        }

        private void MapEncounter()
        {

            CreateMap<DataModels.Monster, Common.Monster>()
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.Profile, opt => opt.MapFrom(s => s.Profile))
                .ForMember(m => m.AdditionalProfiles, opt => opt.MapFrom(s => s.MonsterAdditionalProfiles.Select(m => m.Profile)))
                .ForMember(m => m.SpecialRules, opt => opt.MapFrom(s => s.MonsterSpecialRules.Select(m => m.SpecialRule)))
                .ForMember(m => m.Skills, opt => opt.MapFrom(s => s.MonsterSkills.Select(m => m.Skill)))
                .ForMember(m => m.Equipment, opt =>
                {
                    opt.PreCondition(s => s.MonsterEquipments != null && s.MonsterEquipments.Any());
                    opt.MapFrom(s => s.MonsterEquipments.Select(m => m.Equipment));
                });

            CreateMap<DataModels.Encounter, Common.Encounter>()
                .ForMember(m => m.BottomText, opt => opt.MapFrom(s => s.BottomText))
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.ResultNumber, opt => opt.MapFrom(s => s.ResultNumber))
                .ForMember(m => m.DiceChart, opt => opt.MapFrom(s => s.DiceChart))
                .ForMember(m => m.Monster, opt => opt.MapFrom(s => s.Monster))
                .ForMember(m => m.EncounterTypeId, opt => opt.MapFrom(s => s.EncounterTypeId));

        }

        private void MapWarband()
        {
            CreateMap<DataModels.Warband, Common.Warband>()
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name));
        }

        private void MapHiredSword()
        {
            CreateMap<DataModels.HiredSword, Common.HiredSword>()
                .ForMember(m => m.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(m => m.HireFee, opt => opt.MapFrom(s => s.HireFee))
                .ForMember(m => m.HireFeeDescription, opt => opt.MapFrom(s => s.HireFeeDescription))
                .ForMember(m => m.UpkeepCost, opt => opt.MapFrom(s => s.UpkeepCost))
                .ForMember(m => m.UpkeepCostDescription, opt => opt.MapFrom(s => s.UpkeepCostDescription))
                .ForMember(m => m.CompatabilityDescription, opt => opt.MapFrom(s => s.CompatabilityDescription))
                .ForMember(m => m.Profile, opt => opt.MapFrom(s => s.Profile))
                .ForMember(m => m.Grade, opt => opt.MapFrom(s => s.Grade))
                .ForMember(m => m.Source, opt => opt.MapFrom(s => s.Source))
                .ForMember(m => m.CompatibleWarbands, opt =>
                {
                    opt.PreCondition(s => s.HiredSwordCompatibleWarbands != null && s.HiredSwordCompatibleWarbands.Any());
                    opt.MapFrom(s => s.HiredSwordCompatibleWarbands.Select(m => m.Warband));
                })
                .ForMember(m => m.AdditionalProfiles, opt =>
                {
                    opt.PreCondition(s => s.HiredSwordAdditionalProfiles != null && s.HiredSwordAdditionalProfiles.Any());
                    opt.MapFrom(s => s.HiredSwordAdditionalProfiles.Select(m => m.Profile));
                })
                .ForMember(m => m.Equipment, opt =>
                {
                    opt.PreCondition(s => s.HiredSwordEquipments != null && s.HiredSwordEquipments.Any());
                    opt.MapFrom(s => s.HiredSwordEquipments.Select(m => m.Equipment));
                })
                .ForMember(m => m.SpecialRules, opt =>
                {
                    opt.PreCondition(s => s.HiredSwordSpecialRules != null && s.HiredSwordSpecialRules.Any());
                    opt.MapFrom(s => s.HiredSwordSpecialRules.Select(m => m.SpecialRule));
                })
                .ForMember(m => m.Skills, opt =>
                {
                    opt.PreCondition(s => s.HiredSwordSkills != null && s.HiredSwordSkills.Any());
                    opt.MapFrom(s => s.HiredSwordSkills.Select(m => m.Skill));
                });
        }

        
    }
}

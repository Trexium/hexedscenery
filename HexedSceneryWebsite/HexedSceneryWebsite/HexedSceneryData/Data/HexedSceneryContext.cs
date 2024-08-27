using System;
using System.Collections.Generic;
using HexedSceneryData.Models;
using Microsoft.EntityFrameworkCore;

namespace HexedSceneryData.Data;

public partial class HexedSceneryContext : DbContext
{
    public HexedSceneryContext()
    {
    }

    public HexedSceneryContext(DbContextOptions<HexedSceneryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiceChart> DiceCharts { get; set; }

    public virtual DbSet<DiceResult> DiceResults { get; set; }

    public virtual DbSet<DiceType> DiceTypes { get; set; }

    public virtual DbSet<Encounter> Encounters { get; set; }

    public virtual DbSet<EncounterType> EncounterTypes { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<HiredSword> HiredSwords { get; set; }

    public virtual DbSet<HiredSwordAdditionalProfile> HiredSwordAdditionalProfiles { get; set; }

    public virtual DbSet<HiredSwordCompatibleWarband> HiredSwordCompatibleWarbands { get; set; }

    public virtual DbSet<HiredSwordEquipment> HiredSwordEquipments { get; set; }

    public virtual DbSet<HiredSwordSkill> HiredSwordSkills { get; set; }

    public virtual DbSet<HiredSwordSkillType> HiredSwordSkillTypes { get; set; }

    public virtual DbSet<HiredSwordSpecialRule> HiredSwordSpecialRules { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<ImageCategory> ImageCategories { get; set; }

    public virtual DbSet<ImageImageCategory> ImageImageCategories { get; set; }

    public virtual DbSet<Monster> Monsters { get; set; }

    public virtual DbSet<MonsterAdditionalProfile> MonsterAdditionalProfiles { get; set; }

    public virtual DbSet<MonsterEquipment> MonsterEquipments { get; set; }

    public virtual DbSet<MonsterSkill> MonsterSkills { get; set; }

    public virtual DbSet<MonsterSpecialRule> MonsterSpecialRules { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillType> SkillTypes { get; set; }


    public virtual DbSet<Source> Sources { get; set; }

    public virtual DbSet<SpecialRule> SpecialRules { get; set; }

    public virtual DbSet<TableCategory> TableCategories { get; set; }

    public virtual DbSet<Warband> Warbands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiceChart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiceChar__3214EC073289AA5E");

            entity.ToTable("DiceChart");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Dice).HasMaxLength(25);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<DiceResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiceResu__3214EC072C6BDC4D");

            entity.ToTable("DiceResult");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.DiceChart).WithMany(p => p.DiceResults)
                .HasForeignKey(d => d.DiceChartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DiceResul__DiceC__04AFB25B");
        });

        modelBuilder.Entity<DiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiceType__3214EC07D95A5F38");

            entity.ToTable("DiceType");

            entity.Property(e => e.DisplayName).HasMaxLength(25);
        });

        modelBuilder.Entity<Encounter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Encounte__3214EC077A1170A7");

            entity.ToTable("Encounter");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.DiceChart).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.DiceChartId)
                .HasConstraintName("FK__Encounter__DiceC__0880433F");

            entity.HasOne(d => d.EncounterType).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.EncounterTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Encounter__Encou__1E6F845E");

            entity.HasOne(d => d.Monster).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.MonsterId)
                .HasConstraintName("FK__Encounter__Monst__078C1F06");
        });

        modelBuilder.Entity<EncounterType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Encounte__3214EC07440F7589");

            entity.ToTable("EncounterType");

            entity.Property(e => e.Active).HasDefaultValue(false);
            entity.Property(e => e.DisplayName).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.DiceType).WithMany(p => p.EncounterTypes)
                .HasForeignKey(d => d.DiceTypeId)
                .HasConstraintName("FK_EncounterType_DiceType");

            entity.HasOne(d => d.TableCategory).WithMany(p => p.EncounterTypes)
                .HasForeignKey(d => d.TableCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EncounterType_TableCategory");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipmen__3214EC07B4C2C913");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grade__3214EC07BF251CB9");

            entity.ToTable("Grade");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(25);
        });

        modelBuilder.Entity<HiredSword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HiredSwo__3214EC071480D31A");

            entity.ToTable("HiredSword");

            entity.Property(e => e.CompatabilityDescription).HasMaxLength(500);
            entity.Property(e => e.HireFeeDescription).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Rating).HasMaxLength(255);
            entity.Property(e => e.UpkeepCostDescription).HasMaxLength(500);

            entity.HasOne(d => d.Grade).WithMany(p => p.HiredSwords)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HiredSwor__Grade__5D95E53A");

            entity.HasOne(d => d.Profile).WithMany(p => p.HiredSwords)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HiredSwor__Profi__5CA1C101");

            entity.HasOne(d => d.Source).WithMany(p => p.HiredSwords)
                .HasForeignKey(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HiredSwor__Sourc__5E8A0973");
        });

        modelBuilder.Entity<HiredSwordAdditionalProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HiredSwo__3214EC07B02A90C9");

            entity.ToTable("HiredSwordAdditionalProfile");

            entity.HasOne(d => d.HiredSword).WithMany(p => p.HiredSwordAdditionalProfiles)
                .HasForeignKey(d => d.HiredSwordId)
                .HasConstraintName("FK__HiredSwor__Hired__65370702");

            entity.HasOne(d => d.Profile).WithMany(p => p.HiredSwordAdditionalProfiles)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK__HiredSwor__Profi__662B2B3B");
        });

        modelBuilder.Entity<HiredSwordCompatibleWarband>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HiredSwo__3214EC0780E94CCE");

            entity.ToTable("HiredSwordCompatibleWarband");

            entity.HasOne(d => d.HiredSword).WithMany(p => p.HiredSwordCompatibleWarbands)
                .HasForeignKey(d => d.HiredSwordId)
                .HasConstraintName("FK__HiredSwor__Hired__6166761E");

            entity.HasOne(d => d.Warband).WithMany(p => p.HiredSwordCompatibleWarbands)
                .HasForeignKey(d => d.WarbandId)
                .HasConstraintName("FK__HiredSwor__Warba__625A9A57");
        });

        modelBuilder.Entity<HiredSwordEquipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HiredSwo__3214EC073778AFEE");

            entity.ToTable("HiredSwordEquipment");

            entity.HasOne(d => d.Equipment).WithMany(p => p.HiredSwordEquipments)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK__HiredSwor__Equip__69FBBC1F");

            entity.HasOne(d => d.HiredSword).WithMany(p => p.HiredSwordEquipments)
                .HasForeignKey(d => d.HiredSwordId)
                .HasConstraintName("FK__HiredSwor__Hired__690797E6");
        });

        modelBuilder.Entity<HiredSwordSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HiredSwo__3214EC075A688122");

            entity.ToTable("HiredSwordSkill");

            entity.HasOne(d => d.HiredSword).WithMany(p => p.HiredSwordSkills)
                .HasForeignKey(d => d.HiredSwordId)
                .HasConstraintName("FK__HiredSwor__Hired__70A8B9AE");

            entity.HasOne(d => d.Skill).WithMany(p => p.HiredSwordSkills)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("FK__HiredSwor__Skill__719CDDE7");
        });

        modelBuilder.Entity<HiredSwordSkillType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HiredSwo__3214EC074EB94700");

            entity.ToTable("HiredSwordSkillType");

            entity.HasOne(d => d.HiredSword).WithMany(p => p.HiredSwordSkillTypes)
                .HasForeignKey(d => d.HiredSwordId)
                .HasConstraintName("FK__HiredSwor__Hired__0B5CAFEA");

            entity.HasOne(d => d.SkillType).WithMany(p => p.HiredSwordSkillTypes)
                .HasForeignKey(d => d.SkillTypeId)
                .HasConstraintName("FK__HiredSwor__Skill__0C50D423");
        });

        modelBuilder.Entity<HiredSwordSpecialRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HiredSwo__3214EC0785A1956B");

            entity.ToTable("HiredSwordSpecialRule");

            entity.HasOne(d => d.HiredSword).WithMany(p => p.HiredSwordSpecialRules)
                .HasForeignKey(d => d.HiredSwordId)
                .HasConstraintName("FK__HiredSwor__Hired__6CD828CA");

            entity.HasOne(d => d.SpecialRule).WithMany(p => p.HiredSwordSpecialRules)
                .HasForeignKey(d => d.SpecialRuleId)
                .HasConstraintName("FK__HiredSwor__Speci__6DCC4D03");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Image__3214EC0780E8B11D");

            entity.ToTable("Image");

            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<ImageCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImageCat__3214EC07C70FDE34");

            entity.ToTable("ImageCategory");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<ImageImageCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImageIma__3214EC0700554996");

            entity.ToTable("ImageImageCategory");

            entity.HasOne(d => d.ImageCategoryNavigation).WithMany(p => p.ImageImageCategories)
                .HasForeignKey(d => d.ImageCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImageImag__Image__336AA144");

            entity.HasOne(d => d.Image).WithMany(p => p.ImageImageCategories)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImageImag__Image__32767D0B");
        });

        modelBuilder.Entity<Monster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Monster__3214EC0718987613");

            entity.ToTable("Monster");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Profile).WithMany(p => p.Monsters)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK__Monster__Profile__74794A92");
        });

        modelBuilder.Entity<MonsterAdditionalProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonsterA__3214EC07E9642E5D");

            entity.ToTable("MonsterAdditionalProfile");

            entity.HasOne(d => d.Monster).WithMany(p => p.MonsterAdditionalProfiles)
                .HasForeignKey(d => d.MonsterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterAd__Monst__7EF6D905");

            entity.HasOne(d => d.Profile).WithMany(p => p.MonsterAdditionalProfiles)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterAd__Profi__7FEAFD3E");
        });

        modelBuilder.Entity<MonsterEquipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonsterE__3214EC072FCDA83D");

            entity.ToTable("MonsterEquipment");

            entity.HasOne(d => d.Equipment).WithMany(p => p.MonsterEquipments)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterEq__Equip__4589517F");

            entity.HasOne(d => d.Monster).WithMany(p => p.MonsterEquipments)
                .HasForeignKey(d => d.MonsterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterEq__Monst__44952D46");
        });

        modelBuilder.Entity<MonsterSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonsterS__3214EC07658901DA");

            entity.ToTable("MonsterSkill");

            entity.HasOne(d => d.Monster).WithMany(p => p.MonsterSkills)
                .HasForeignKey(d => d.MonsterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterSk__Monst__7755B73D");

            entity.HasOne(d => d.Skill).WithMany(p => p.MonsterSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterSk__Skill__7849DB76");
        });

        modelBuilder.Entity<MonsterSpecialRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MosterSp__3214EC07E1067BE5");

            entity.ToTable("MonsterSpecialRule");

            entity.HasOne(d => d.Monster).WithMany(p => p.MonsterSpecialRules)
                .HasForeignKey(d => d.MonsterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MosterSpe__Monst__7B264821");

            entity.HasOne(d => d.SpecialRule).WithMany(p => p.MonsterSpecialRules)
                .HasForeignKey(d => d.SpecialRuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MosterSpe__Speci__7C1A6C5A");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profile__3214EC07164073F8");

            entity.ToTable("Profile");

            entity.Property(e => e.Attacks).HasMaxLength(25);
            entity.Property(e => e.BallisticSkill).HasMaxLength(25);
            entity.Property(e => e.Initiative).HasMaxLength(25);
            entity.Property(e => e.Leadership).HasMaxLength(25);
            entity.Property(e => e.Movement).HasMaxLength(25);
            entity.Property(e => e.Name).HasMaxLength(25);
            entity.Property(e => e.Strength).HasMaxLength(25);
            entity.Property(e => e.Toughness).HasMaxLength(25);
            entity.Property(e => e.WeaponSkill).HasMaxLength(25);
            entity.Property(e => e.Wounds).HasMaxLength(25);
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Race__3214EC074146DC4A");

            entity.ToTable("Race");

            entity.Property(e => e.Name).HasMaxLength(25);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skill__3214EC078285D64C");

            entity.ToTable("Skill");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.SkillType).WithMany(p => p.Skills)
                .HasForeignKey(d => d.SkillTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Skill__SkillType__540C7B00");
        });

        modelBuilder.Entity<SkillType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SkillTyp__3214EC079C46C59A");

            entity.ToTable("SkillType");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Source>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Source__3214EC07995FA1E4");

            entity.ToTable("Source");

            entity.Property(e => e.Key).HasMaxLength(25);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PdfUrl).HasMaxLength(255);
        });

        modelBuilder.Entity<SpecialRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialR__3214EC07FD5D949E");

            entity.ToTable("SpecialRule");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TableCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TableCat__3214EC0745B3BBEF");

            entity.ToTable("TableCategory");

            entity.Property(e => e.Active).HasDefaultValue(false);
            entity.Property(e => e.DisplayName).HasMaxLength(255);
        });

        modelBuilder.Entity<Warband>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warband__3214EC070330C6FC");

            entity.ToTable("Warband");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Race).WithMany(p => p.Warbands)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__Warband__RaceId__1B9317B3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

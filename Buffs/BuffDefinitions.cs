using System.Collections.Generic;
using System.Reflection;
using System.IO;
using QuackCore.BuffSystem;
using QuackCore.BuffSystem.Effects;
using QuackCore.BuffSystem.Logic;
using QuackCore.Constants;

namespace TarkovStimulants.Buffs
{
    public static class BuffDefinitions
    {
        private static readonly string DllDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static string GetIconPath(string fileName)
            => Path.Combine(DllDir, $"assets/textures/buffs/{fileName}.png");

        public static readonly QuackBuffDefinition ETGc_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "eTGc_Buff", 999001, 15f,
                    GetIconPath("eTG-c")))
                .AddCustomLogic(new RegenerationLogic(0.08f, 0.5f, -1, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 2f, true));

        public static readonly QuackBuffDefinition SJ12_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "SJ12_Buff", 999002, 120f,
                    GetIconPath("SJ12")))
                .AddCustomLogic(new EnegyWaterRestoreLogic(0.1f, 0.3f, 2f))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.SenseRange, 1.2f, true));

        public static readonly QuackBuffDefinition Propital_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Propital_Buff", 999003, 180f,
                    GetIconPath("Propital")))
                .AddCustomLogic(new RegenerationLogic(0.01f, 1f, 60f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxHealth, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 0.9f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 0.9f, true));

        public static readonly QuackBuffDefinition SJ6_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "SJ6_Buff", 999004, 90f,
                    GetIconPath("SJ6")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 2.0f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 1.5f, true));

        public static readonly QuackBuffDefinition MULE_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "MULE_Buff", 999005, 240f,
                    GetIconPath("MULE")))
                .AddCustomLogic(new RegenerationLogic(-0.002f, 1.0f, -1f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxWeight, 2f, true));

        public static readonly QuackBuffDefinition Adrenaline_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Adrenaline_Buff", 999006, 60f,
                    GetIconPath("Adrenaline")))
                .AddCustomLogic(new RegenerationLogic(0.05f, 1f, 15f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 1.1f, true));

        public static readonly QuackBuffDefinition Meldonin_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Meldonin_Buff", 999007, 180f,
                    GetIconPath("Meldonin")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WalkSpeed, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.RunSpeed, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 1.2f, true));

        public static readonly QuackBuffDefinition Morphine_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Morphine_Buff", 999008, 60f,
                    GetIconPath("Adrenaline")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 1.1f, true));
        
        public static readonly QuackBuffDefinition L1_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "L1_Buff", 999009, 90f,
                    GetIconPath("L1")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 1.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 1.1f, true));

        public static readonly QuackBuffDefinition Stim_3bTG_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "3bTG_Buff", 999010, 180f,
                    GetIconPath("3-(b-TG)")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 1.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.SenseRange, 1.4f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 1.1f, true));

        public static readonly QuackBuffDefinition Perfotoran_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Perfotoran_Buff", 999011, 60f,
                    GetIconPath("Perfotoran")))
                .AddCustomLogic(new RegenerationLogic(0.01f, 1f, 30f, false))
                .AddCustomLogic(new BuffImmunityLogic(false, 1061))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 1.1f, true));

        public static readonly QuackBuffDefinition Stim_2A2bTG_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "2A2bTG_Buff", 999012, 180f,
                    GetIconPath("2A2-(b-TG)")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.SenseRange, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxWeight, 1.3f, true));
        
        public static readonly QuackBuffDefinition P22_Buff = 
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "P22_Buff", 999013, 60f, GetIconPath("P22")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Physics, 0.85f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.HealGain, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 0.9f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 0.8f, true));
        
        public static readonly QuackBuffDefinition Obdolbos2_Buff = 
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Obdolbos2_Buff", 999014, 600f, GetIconPath("Obdolbos 2")))
                .AddCustomLogic(new RegenerationLogic(-0.002f, 1.0f, -1f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxWeight, 1.45f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.SenseRange, 1.4f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WalkSpeed, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.RunSpeed, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 0.9f, true))     
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 0.9f, true));
        
        public static readonly QuackBuffDefinition Trimadol_Buff = 
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Trimadol_Buff", 999015, 180f, GetIconPath("Trimadol")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 2.0f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WalkSpeed, 1.15f, true))
                .AddCustomLogic(new EnegyWaterRestoreLogic(-0.1f, -0.2f, 1f));

        public static readonly QuackBuffDefinition SJ1_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "SJ1_Buff", 999016, 90f,
                    GetIconPath("SJ1")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WalkSpeed, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.RunSpeed, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 1.2f, true));

        public static readonly QuackBuffDefinition Zagustin_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Zagustin_Buff", 999017, 180f,
                    GetIconPath("Zagustin")))
                .AddCustomLogic(new BuffImmunityLogic(false, 1001))
                .AddCustomLogic(new EnegyWaterRestoreLogic(0f, -0.05f, 1f))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.HealGain, 1.2f, true));
        
        public static readonly QuackBuffDefinition SJ9_Buff = 
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "SJ9_Buff", 999018, 180f, GetIconPath("SJ9")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WalkSoundRange, 0.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.RunSoundRange, 0.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.VisableDistanceFactor, 0.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 0.8f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 0.8f, true))
                .AddCustomLogic(new RegenerationLogic(-0.002f, 1f, -1f, false));

        public static readonly List<QuackBuffDefinition> AllBuffs = new List<QuackBuffDefinition>
        {
            ETGc_Buff,
            SJ12_Buff,
            Propital_Buff,
            SJ6_Buff,
            MULE_Buff,
            Adrenaline_Buff,
            Meldonin_Buff,
            Morphine_Buff,
            L1_Buff,
            Stim_3bTG_Buff,
            Perfotoran_Buff,
            Stim_2A2bTG_Buff,
            P22_Buff,
            Obdolbos2_Buff,
            Trimadol_Buff,
            SJ1_Buff,
            Zagustin_Buff,
            SJ9_Buff
        };
    }
}
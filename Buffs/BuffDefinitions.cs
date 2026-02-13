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

        #region 辅助用Debuff
        
        // 震颤Debuff，减少30%后坐力控制，增加30%枪械散步
        public static readonly QuackBuffDefinition Tremor_Debuff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Tremor_Debuff", 999301, 10f,
                    GetIconPath("Tremor")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunScatterMultiplier, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.RecoilControl, 0.7f, true));
        
        // 管视效应Debuff，减少50%视野角度
        public static readonly QuackBuffDefinition TunnelVision_Debuff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "TunnelVision_Debuff", 999302,
                    10f, GetIconPath("TunnelVision")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ViewAngle, 0.5f, true));
        
        // 即死Debuff，持续2s快速掉血
        public static readonly QuackBuffDefinition InstantDeath_Debuff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "InstantDeath_Debuff", 999303,
                    1f, GetIconPath("Death")))
                .AddCustomLogic(new RegenerationLogic(-10.0f, 0.1f, 2f, true));
        
        #endregion
        
        
        // 1. eTG-change (绿针)
        /// <summary>
        /// 1秒延迟；90秒持续时间:代谢（+20）免疫（+20）
        /// 1秒延迟；60秒持续时间:生命恢复（+6.5/秒）能量恢复（+0.5/秒）
        /// </summary>
        public static readonly QuackBuffDefinition eTGc_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "eTGc_Buff", 999101, 60f,
                    GetIconPath("eTG-c")))
                .AddCustomLogic(new RegenerationLogic(0.2f, 1.0f)) // 初始40血，约8/s
                .AddCustomLogic(new EnegyWaterRestoreLogic(0.5f, 0f))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 0.8f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 0.8f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Fire, -0.1f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Poison, -0.1f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Electricity, -0.1f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Space, -0.1f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Ghost, -0.1f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Ice, -0.1f, false))
                .AddCustomLogic(new DelayedBuffLogic("ETGc_Debuff", 65f));
        /// <summary>
        /// 65秒延迟；60秒持续时间: 耐力（-5）健康（-5）
        /// 65秒延迟；20秒持续时间: 能量恢复（-3/秒）
        /// </summary>
        public static readonly QuackBuffDefinition eTGc_Debuff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "eTGc_Debuff", 999401, 20f,
                    GetIconPath("eTG-c")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, -30, false))
                .AddCustomLogic(new EnegyWaterRestoreLogic(-2f, 0f));

        // 2. SJ12 (代谢针)
        /// <summary>
        /// 1秒延迟；600秒持续时间: 感知（+30）
        /// 降低体温（-4°C） 能量恢复（+0.1） 水分恢复（+0.1）
        /// 
        /// 606秒延迟；300秒持续时间: 提高体温（+6 °C）
        /// </summary>
        public static readonly QuackBuffDefinition SJ12_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "SJ12_Buff", 999102, 300f,
                    GetIconPath("SJ12")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.SenseRange, 1.3f, true))
                .AddCustomLogic(new EnegyWaterRestoreLogic(0.05f, 0.05f));
        
        // 3. Propital (普罗皮醛)
        /// <summary>
        /// 移除眩晕、疼痛，持续240s，止痛 240s
        /// 1秒延迟；300秒持续时间: 代谢（+20）健康（+20）活力（+20）生命恢复（+1/秒）
        /// 
        /// 270秒延迟；30秒持续时间: 管视效应，震颤
        /// </summary>
        public static readonly QuackBuffDefinition Propital_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Propital_Buff", 999103, 240f,
                    GetIconPath("Propital")))
                .AddCustomLogic(new RegenerationLogic(0.04f, 1.0f)) // 1.6 HP/s
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxHealth, 20f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 0.9f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 0.9f, true))
                //.AddCustomLogic(new BuffImmunityLogic(false, 1001, 1002)) // 止血
                .AddCustomLogic(new DelayedBuffLogic("Tremor_Debuff", 200f))
                .AddCustomLogic(new DelayedBuffLogic("TunnelVision_Debuff", 200f));
        
        
        // 4. SJ6 (耐力针)
        /// <summary>
        /// 1秒延迟；240秒持续时间:最大耐力（+30）耐力恢复（+2/秒）
        ///
        /// 200秒延迟；40秒持续时间: 管视效应，震颤
        /// </summary>
        public static readonly QuackBuffDefinition SJ6_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "SJ6_Buff", 999104, 240f,
                    GetIconPath("SJ6")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 50f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverTime, 0.8f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WalkSpeed, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.RunSpeed, 1.1f, true))
                .AddCustomLogic(new DelayedBuffLogic("Tremor_Debuff", 200f))
                .AddCustomLogic(new DelayedBuffLogic("TunnelVision_Debuff", 200f));

        // 5. M.U.L.E. (负重针)
        /// <summary>
        /// 1秒延迟；900秒持续时间:增加重量限制（+50%）
        ///
        /// 1秒延迟；900秒持续时间:生命恢复（-0.1/秒）
        /// </summary>
        public static readonly QuackBuffDefinition MULE_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "MULE_Buff", 999105, 600f,
                    GetIconPath("MULE")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxWeight, 2f, true))
                .AddCustomLogic(new RegenerationLogic(-0.005f, 1.0f)); // 总计300%生命

        // 6. Adrenaline (肾上腺素)
        /// <summary>
        /// 移除眩晕、疼痛，持续60s，止痛60s
        /// 1秒延迟；60秒持续时间:耐力（+10）力量（+10）1秒延迟；15秒持续时间:生命恢复（+4/秒）
        /// 
        /// 1秒延迟；60秒持续时间:抗压（-10）50秒延迟；30秒持续时间:水分恢复（-1/秒）能量恢复（-0.8/秒）
        /// </summary>
        public static readonly QuackBuffDefinition Adrenaline_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Adrenaline_Buff", 999106, 60f,
                    GetIconPath("Adrenaline")))
                .AddCustomLogic(new RegenerationLogic(0.1f, 1.0f,15))
                //.AddCustomLogic(new BuffImmunityLogic(false, 1001, 1002)) // 止血
                .AddEffect(new ApplyBuffEffect("1082_Buff_PainResistShort",60))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 1.1f, true))
                .AddCustomLogic(new DelayedBuffLogic("Adrenaline_Debuff", 50f));
        
        public static readonly QuackBuffDefinition Adrenaline_Debuff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Adrenaline_Debuff", 999406, 15f,
                    GetIconPath("Adrenaline")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Physics, -0.1f, false))
                .AddCustomLogic(new EnegyWaterRestoreLogic(-1f, -1f));
        
        // 7. Meldonin (米屈肼)
        /// <summary>
        /// 1秒延迟；900秒持续时间:力量（+10）耐力（+20）耐力恢复（+0.5/秒）
        /// 30秒延迟；900秒持续时间:能量恢复（-0.1/秒）水分恢复（-0.1/秒）
        /// </summary>
        public static readonly QuackBuffDefinition Meldonin_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Meldonin_Buff", 999107, 600f,
                    GetIconPath("Meldonin")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 20f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MeleeDamageMultiplier, 1.1f, true))
                .AddCustomLogic(new EnegyWaterRestoreLogic(-0.05f, -0.05f));
        
        // 8. Morphine (吗啡)
        /// <summary>
        /// 移除眩晕、疼痛，持续305s，止痛305s
        /// 
        /// 能量（-10）水分（-15）
        /// </summary>
        public static readonly QuackBuffDefinition Morphine_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Morphine_Buff", 999108, 300f,
                    GetIconPath("Morphine")))
                .AddCustomLogic(new BuffImmunityLogic(false, 1003, 1004)) //预防骨折，创伤
                .AddEffect(new ApplyBuffEffect("1084_Buff_PainResistLong",-1));

        // 9. L1 (去甲肾上腺素)
        /// <summary>
        /// 移除疼痛，持续120s，止痛120s
        /// 1秒延迟；120秒持续时间:耐力（+10）力量（+20）最大耐力（+30）
        ///
        /// 1秒延迟；60秒持续时间:能量恢复（-0.4/秒）水分恢复（-0.4/秒）
        /// </summary>
        public static readonly QuackBuffDefinition L1_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "L1_Buff", 999109, 120f,
                    GetIconPath("L1")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 20f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 1.2f, true))
                .AddCustomLogic(new EnegyWaterRestoreLogic(-0.06f, -0.06f,2f));
                
        // 10. Stim_3bTG (感知针)
        /// <summary>
        /// 1秒延迟；240秒持续时间:专注（+30）感知（+30）力量（+10）耐力恢复（+1/秒）
        ///
        /// 120秒延迟；120秒持续时间:能量恢复（-0.2/秒）220秒延迟；45秒持续时间: 造成:震颤
        /// </summary>
        public static readonly QuackBuffDefinition Stim_3bTG_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Stim_3bTG_Buff", 999110, 180f,
                    GetIconPath("3-(b-TG)")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.SenseRange, 1.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.FishingTime, 0.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.FishingQualityFactor, 2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 1.1f, true))
                .AddCustomLogic(new DelayedBuffLogic("Tremor_Debuff", 120f));

        // 11. Perfotoran (蓝血)
        /// <summary>
        /// 1秒延迟；60秒持续时间:代谢（+5）生命恢复（+1.5/秒）解毒剂（去除和预防）停止和防止
        /// </summary>
        public static readonly QuackBuffDefinition Perfotoran_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Perfotoran_Buff", 999111, 60f,
                    GetIconPath("Perfotoran")))
                .AddCustomLogic(new RegenerationLogic(0.08f, 1.0f))
                .AddEffect(new ApplyBuffEffect("1075_Buff_PoisonResistShort", 60))
                .AddEffect(new ApplyBuffEffect("1019_buff_Injector_BleedResist",-1));
                //.AddCustomLogic(new BuffImmunityLogic(false, 1001, 1002, 1061));

        // 12. Stim_2A2bTG (侦察针)
        /// <summary>
        /// 1秒延迟；900秒持续时间:专注（+10）感知（+10）重量限制（+15%）
        ///
        /// 1秒延迟；900秒持续时间:水分（-0.1）
        /// </summary>
        public static readonly QuackBuffDefinition Stim_2A2bTG_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Stim_2A2bTG_Buff", 999112, 600f, 
                    GetIconPath("2A2-(b-TG)")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxWeight, 1.15f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.SenseRange, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.FishingTime, 0.7f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.FishingQualityFactor, 1.3f, true));

        // 13. P22 (防护针)
        /// <summary>
        /// 1秒延迟；60秒持续时间:抗压（+30）健康（+30）活力（+30）
        ///
        /// 65秒延迟；60秒持续时间:耐力（-10）耐力恢复（-0.8/秒）
        /// </summary>
        public static readonly QuackBuffDefinition P22_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "P22_Buff", 999113, 60f,
                    GetIconPath("P22")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Physics, -0.25f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxHealth, 40f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, -20f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 0.8f, true));
        
        // 14. Obdolbos 2 (鸡尾酒2)
        /// <summary>
        /// 1秒延迟；1800秒持续时间:耐力（+20）力量（+20）专注（+20）感知（+20）重量限制（+45%）
        ///
        /// 1秒延迟；1800秒持续时间:最大耐力（-20）耐力恢复（-1/秒）生命恢复（-1/秒）
        /// </summary>
        public static readonly QuackBuffDefinition Obdolbos2_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Obdolbos2_Buff", 999114, 1200f,
                    GetIconPath("Obdolbos 2")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxWeight, 1.6f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.RunSpeed, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.SenseRange, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.FishingTime, 0.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.FishingQualityFactor, 1.7f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 1.2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MeleeDamageMultiplier, 1.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, -20f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 0.9f, true))
                .AddCustomLogic(new RegenerationLogic(-0.01f, 1.0f));

        // 15. Trimadol (特美多)
        /// <summary>
        /// 移除眩晕、疼痛，持续180s，止痛180s
        /// 1秒延迟；180秒持续时间:耐力（+10）力量（+10）专注（+10）抗压（+10）最大耐力（+10）耐力恢复（+3/秒）
        ///
        /// 1秒延迟；180秒持续时间:能量恢复（-0.5/秒）水分恢复（-0.5/秒）
        /// </summary>
        public static readonly QuackBuffDefinition Trimadol_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Trimadol_Buff", 999115, 240f,
                    GetIconPath("Trimadol")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverRate, 2f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 20f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WalkSpeed, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.RunSpeed, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.StaminaRecoverTime, 0.5f, true))
                .AddCustomLogic(new EnegyWaterRestoreLogic(-0.05f, -0.05f));

        // 16. SJ1 (体能针)
        /// <summary>
        /// 1秒延迟；180秒持续时间:耐力（+20）力量（+20）抗压（+20）
        ///
        /// 100秒延迟；200秒持续时间:能量恢复（-0.2/秒）水分恢复（-0.3/秒）
        /// </summary>
        public static readonly QuackBuffDefinition SJ1_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "SJ1_Buff", 999116, 90f,
                    GetIconPath("SJ1")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.RunSpeed, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.ElementFactor_Physics, -0.1f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 1.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 1.1f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 1.1f, true));

        // 17. Zagustin (止血针)
        /// <summary>
        /// 移除:持续出血180秒 1秒延迟；180秒持续时间:活力（+20）
        ///
        /// 造成:仅在治疗大出血时出现1秒延迟；180秒持续时间:代谢（-5）170秒延迟；40秒持续时间:水分恢复（-1.4）造成震颤
        /// </summary>
        public static readonly QuackBuffDefinition Zagustin_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Zagustin_Buff", 999117, 180f,
                    GetIconPath("Zagustin")))
                .AddCustomLogic(new BuffImmunityLogic(false, 1001,1002))
                .AddEffect(new ApplyBuffEffect("1019_buff_Injector_BleedResist",180))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxHealth, 30f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 1.25f, true));

        // 18. SJ9 (冷血针)
        /// <summary>
        /// 6秒延迟；300秒持续时间:降低体温（-7°C）
        ///
        /// 6秒延迟；300秒持续时间:代谢（-20）6秒延迟；420秒持续时间:生命恢复（-0.1/秒）造成:震颤300秒延迟；120秒持续时间:造成:疼痛
        /// </summary>
        public static readonly QuackBuffDefinition SJ9_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "SJ9_Buff", 999118, 180f,
                    GetIconPath("SJ9")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.VisableDistanceFactor, 0.5f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.WaterCost, 0.7f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.EnergyCost, 0.7f, true))
                .AddCustomLogic(new RegenerationLogic(-0.002f, 1f))
                .AddCustomLogic(new DelayedBuffLogic("Tremor_Debuff", 120f));
        

        // 19. AHF1-M (凝血针)
        public static readonly QuackBuffDefinition AHF1M_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "AHF1M_Buff", 999119, 60f,
                    GetIconPath("AHF1-M")))
                .AddCustomLogic(new BuffImmunityLogic(false, 1019));

        // 20. Obdolbos (鸡尾酒1)
        public static readonly QuackBuffDefinition Obdolbos_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "Obdolbos_Buff", 999120, 600f,
                    GetIconPath("Obdolbos")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 20f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 0.2f, true));

        // 21. PNB (肌肉针)
        public static readonly QuackBuffDefinition PNB_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "PNB_Buff", 999121, 40f,
                    GetIconPath("PNB")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.GunDamageMultiplier, 0.15f, true))
                .AddCustomLogic(new RegenerationLogic(0.075f, 1.0f));

        // 22. xTG-12 (解毒针)
        public static readonly QuackBuffDefinition xTG12_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "xTG12_Buff", 999122, 60f,
                    GetIconPath("xTG-12")))
                .AddCustomLogic(new BuffImmunityLogic(false, 1016));

        // 23. SJ15 (巅峰针)
        public static readonly QuackBuffDefinition SJ15_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "SJ15_Buff", 999123, 900f,
                    GetIconPath("SJ15")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxWeight, 0.3f, true))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.Stamina, 40f, false))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxHealth, 40f, false));

        // 24. Obdolbos N
        public static readonly QuackBuffDefinition ObdolbosN_Buff =
            new QuackBuffDefinition(new QuackBuffFactory.BuffConfig("TarkovStimulants", "ObdolbosN_Buff", 999124, 1800f,
                    GetIconPath("ObdolbosN")))
                .AddEffect(new AttributeModifierEffect(ModifierKeyConstant.Stat.MaxHealth, 0.5f, true));

        public static readonly List<QuackBuffDefinition> AllBuffs = new List<QuackBuffDefinition>
        {
            eTGc_Buff, eTGc_Debuff,
            SJ12_Buff, 
            Propital_Buff, 
            SJ6_Buff, 
            MULE_Buff, 
            Adrenaline_Buff, Adrenaline_Debuff,
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
            SJ9_Buff, 
            AHF1M_Buff, 
            Obdolbos_Buff, 
            PNB_Buff, 
            xTG12_Buff,
            SJ15_Buff, 
            ObdolbosN_Buff, 
            
            Tremor_Debuff, TunnelVision_Debuff, InstantDeath_Debuff
        };
    }
}
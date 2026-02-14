using System.Collections.Generic;
using FastModdingLib;
using ItemStatsSystem;
using QuackCore.Constants;
using QuackCore.Items;
using QuackCore.Items.UsageData;

namespace TarkovStimulants.Items
{
    public static class ItemDefinitions
    {
        // 1. eTG-change (绿针) - 品阶4, 价格3500
        public static readonly QuackItemDefinition Stim_eTGc = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999001,
                order = 100,
                localizationKey = "Stim_eTGc",
                localizationDesc = "Stim_eTGc_Desc",
                weight = 0.1f,
                value = 3500,
                quality = 5,
                displayQuality = DisplayQuality.Orange,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/eTG-c.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -10f, waterValue = -20f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_eTGc_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 1,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            },
            Crafting = new QuackItemDefinition.CraftingConfig
            {
                FormulaID = "formula_eTGc_craft",
                MoneyCost = 0L,
                Materials = new List<(int itemId, long count)>
                {
                    (136, 3L), //注射器
                    (875, 3L), //回复针
                    (14, 1L) //可乐
                },
                ResultCount = 3,
                Workbenches = new string[] { WorkbenchIDs.MedicStation },
                UnlockByDefault = true,
                RequirePerk = "",
                HideInIndex = false,
                LockInDemo = false
            },
            // Decompose = new QuackItemDefinition.DecomposeConfig
            // {
            //     MoneyGain = 0L,
            //     Results = new List<(int itemId, long count)>
            //     {
            //         (88, 1L)
            //     }
            // }
        };

        // 2. SJ12 (代谢针) - 品阶3, 价格2350
        public static readonly QuackItemDefinition Stim_SJ12 = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999002,
                order = 101,
                localizationKey = "Stim_SJ12",
                localizationDesc = "Stim_SJ12_Desc",
                weight = 0.1f,
                value = 850,
                quality = 3,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/SJ12.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = 5f, waterValue = 10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_SJ12_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 3,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            },
            Crafting = new QuackItemDefinition.CraftingConfig
            {
                FormulaID = "formula_SJ12_craft",
                MoneyCost = 0L,
                Materials = new List<(int itemId, long count)>
                {
                    (136, 3L), // 注射器
                    (428, 1L), // 瓶装水
                    (132, 2L) //蛋糕
                },
                ResultCount = 3,
                Workbenches = new string[] { WorkbenchIDs.MedicStation },
                UnlockByDefault = true,
                RequirePerk = "",
                HideInIndex = false,
                LockInDemo = false
            },
        };

        // 3. Propital (普罗皮醛) - 品阶2, 价格850
        public static readonly QuackItemDefinition Stim_Propital = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999003,
                order = 102,
                localizationKey = "Stim_Propital",
                localizationDesc = "Stim_Propital_Desc",
                weight = 0.1f,
                value = 1200,
                quality = 3,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/Propital.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -5f, waterValue = -10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_Propital_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 3,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            },
            Crafting = new QuackItemDefinition.CraftingConfig
            {
                FormulaID = "formula_Propital_craft",
                MoneyCost = 0L,
                Materials = new List<(int itemId, long count)>
                {
                    (136, 3L), // 注射器
                    (875, 1L),
                    (1247, 1L)
                },
                ResultCount = 3,
                Workbenches = new string[] { WorkbenchIDs.MedicStation },
                UnlockByDefault = true
            }
        };

        // 4. SJ6 (耐力针) - 品阶4, 价格3200
        public static readonly QuackItemDefinition Stim_SJ6 = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999004,
                order = 103,
                localizationKey = "Stim_SJ6",
                localizationDesc = "Stim_SJ6_Desc",
                weight = 0.1f,
                value = 648,
                quality = 2,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/SJ6.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -5f, waterValue = -10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_SJ6_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 3,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            },
            Crafting = new QuackItemDefinition.CraftingConfig
            {
                FormulaID = "formula_SJ6_craft",
                Materials = new List<(int itemId, long count)> { (136, 3L), (137, 2L), (88, 2L) },
                ResultCount = 3,
                Workbenches = new string[] { WorkbenchIDs.MedicStation },
                UnlockByDefault = true
            }
        };

        // 5. M.U.L.E. (负重针) - 品阶4, 价格3650
        public static readonly QuackItemDefinition Stim_MULE = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999005,
                order = 104,
                localizationKey = "Stim_MULE",
                localizationDesc = "Stim_MULE_Desc",
                weight = 0.1f,
                value = 1650,
                quality = 4,
                displayQuality = DisplayQuality.Purple,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/MULE.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -5f, waterValue = -10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_MULE_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 1,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            },
            Crafting = new QuackItemDefinition.CraftingConfig
            {
                FormulaID = "formula_MULE_craft",
                Materials = new List<(int itemId, long count)> { (136, 3L), (398, 2L), (84, 1L) },
                ResultCount = 3,
                Workbenches = new string[] { WorkbenchIDs.MedicStation },
                UnlockByDefault = true
            }
        };

        // 6. Adrenaline (肾上腺素) - 品阶2, 价格610
        public static readonly QuackItemDefinition Stim_Adrenaline = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999006,
                order = 105,
                localizationKey = "Stim_Adrenaline",
                localizationDesc = "Stim_Adrenaline_Desc",
                weight = 0.1f,
                value = 610,
                quality = 2,
                displayQuality = DisplayQuality.Green,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/Adrenaline.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -5f, waterValue = -10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_Adrenaline_Buff", chance = 1.0f },
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 5,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            },
            Crafting = new QuackItemDefinition.CraftingConfig
            {
                FormulaID = "formula_Adrenaline_craft",
                Materials = new List<(int itemId, long count)> { (136, 3L), (409, 2L), (88, 1L) },
                ResultCount = 3,
                Workbenches = new string[] { WorkbenchIDs.MedicStation },
                UnlockByDefault = true
            }
        };

        // 7. Meldonin (米屈肼) - 品阶3, 价格2100
        public static readonly QuackItemDefinition Stim_Meldonin = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999007,
                order = 106,
                localizationKey = "Stim_Meldonin",
                localizationDesc = "Stim_Meldonin_Desc",
                weight = 0.1f,
                value = 1500,
                quality = 3,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/Meldonin.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -5f, waterValue = -10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_Meldonin_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 3,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            },
            Crafting = new QuackItemDefinition.CraftingConfig
            {
                FormulaID = "formula_Meldonin_craft",
                Materials = new List<(int itemId, long count)> { (136, 3L), (137, 4L), (1180, 1L) },
                ResultCount = 3,
                Workbenches = new string[] { WorkbenchIDs.MedicStation },
                UnlockByDefault = true
            }
        };

        // 8. Morphine (吗啡) - 品阶2, 价格580
        public static readonly QuackItemDefinition Stim_Morphine = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999008,
                order = 107,
                localizationKey = "Stim_Morphine",
                localizationDesc = "Stim_Morphine_Desc",
                weight = 0.1f,
                value = 580,
                quality = 2,
                displayQuality = DisplayQuality.Green,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/Morphine.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -10f, waterValue = -15f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_Morphine_Buff", chance = 1.0f },
                        //new AddBuffData { buff = 1019, chance = 1f },
                        //new AddBuffData { buff = 1083, chance = 1f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 5,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            }
        };

        // 9. L1 (去甲肾上腺素) - 品阶2, 价格880
        public static readonly QuackItemDefinition Stim_L1 = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999009,
                order = 108,
                localizationKey = "Stim_L1",
                localizationDesc = "Stim_L1_Desc",
                weight = 0.1f,
                value = 880,
                quality = 3,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/L1.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -15f, waterValue = -15f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_L1_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 3,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            }
        };

        // 10. 3-(b-TG) (感知针) - 品阶3, 价格2300
        public static readonly QuackItemDefinition Stim_3bTG = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999010,
                order = 109,
                localizationKey = "Stim_3bTG",
                localizationDesc = "Stim_3bTG_Desc",
                weight = 0.1f,
                value = 1700,
                quality = 3,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/3-(b-TG).png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_3bTG_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 2,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            }
        };

        // 11. Perfotoran (蓝血) - 品阶3, 价格2150
        public static readonly QuackItemDefinition Stim_Perfotoran = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999011,
                order = 110,
                localizationKey = "Stim_Perfotoran",
                localizationDesc = "Stim_Perfotoran_Desc",
                weight = 0.1f,
                value = 2150,
                quality = 3,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/Perfotoran.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -5f, waterValue = -10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_Perfotoran_Buff", chance = 1.0f },
                        //new RemoveBuffData { buffID = 1001 },
                        //new AddBuffData { buff = 1019, chance = 1f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 2,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            }
        };

        // 12. 2A2-(b-TG) (侦察针) - 品阶3, 价格2400
        public static readonly QuackItemDefinition Stim_2A2bTG = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999012,
                order = 111,
                localizationKey = "Stim_2A2bTG",
                localizationDesc = "Stim_2A2bTG_Desc",
                weight = 0.1f,
                value = 648,
                quality = 3,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/2A2-(b-TG).png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { waterValue = -15f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_Stim_2A2bTG_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 2,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            },
            Crafting = new QuackItemDefinition.CraftingConfig
            {
                FormulaID = "formula_2A2bTG_craft",
                Materials = new List<(int itemId, long count)> { (999010, 1L), (137, 2L) }, // 使用3bTG作为原材料之一
                ResultCount = 1,
                Workbenches = new string[] { WorkbenchIDs.MedicStation },
                UnlockByDefault = true
            }
        };

        // 13. P22 (防护针) - 品阶2, 价格920
        public static readonly QuackItemDefinition Stim_P22 = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999013,
                order = 112,
                localizationKey = "Stim_P22",
                localizationDesc = "Stim_P22_Desc",
                weight = 0.1f,
                value = 2400,
                quality = 5,
                displayQuality = DisplayQuality.Orange,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/P22.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { waterValue = -10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_P22_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 3,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            }
        };

        // 14. Obdolbos 2 - 品阶4, 价格4500
        public static readonly QuackItemDefinition Stim_Obdolbos2 = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999014,
                order = 113,
                localizationKey = "Stim_Obdolbos2",
                localizationDesc = "Stim_Obdolbos2_Desc",
                weight = 0.1f,
                value = 4500,
                quality = 5,
                displayQuality = DisplayQuality.Orange,
                maxStackCount = 1,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/Obdolbos 2.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -20f, waterValue = -20f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_Obdolbos2_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 1,
                PriceFactor = 1.0f,
                Probability = 0.5f,
                ForceUnlock = true
            }
        };

        // 15. Trimadol (特美多) - 品阶4, 价格4200
        public static readonly QuackItemDefinition Stim_Trimadol = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999015,
                order = 114,
                localizationKey = "Stim_Trimadol",
                localizationDesc = "Stim_Trimadol_Desc",
                weight = 0.1f,
                value = 3200,
                quality = 4,
                displayQuality = DisplayQuality.Purple,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/Trimadol.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new QuackAddBuffData { buffName = "TarkovStimulants_Trimadol_Buff", chance = 1.0f },
                        new RemoveBuffData { buffID = 1001 }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 2,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            }
        };

        // 16. SJ1 (体能针) - 品阶3, 价格1800
        public static readonly QuackItemDefinition Stim_SJ1 = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999016,
                order = 115,
                localizationKey = "Stim_SJ1",
                localizationDesc = "Stim_SJ1_Desc",
                weight = 0.1f,
                value = 750,
                quality = 3,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/SJ1.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -8f, waterValue = -14f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_SJ1_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 3,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            }
        };

        // 17. Zagustin (止血针) - 品阶3, 价格1850
        public static readonly QuackItemDefinition Stim_Zagustin = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999017,
                order = 116,
                localizationKey = "Stim_Zagustin",
                localizationDesc = "Stim_Zagustin_Desc",
                weight = 0.1f,
                value = 1050,
                quality = 3,
                displayQuality = DisplayQuality.Blue,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/Zagustin.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new QuackAddBuffData { buffName = "TarkovStimulants_Zagustin_Buff", chance = 1.0f },
                        new RemoveBuffData { buffID = 1001 }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 2,
                PriceFactor = 1.0f,
                Probability = 1.0f,
                ForceUnlock = true
            }
        };

        // 18. SJ9 (冷血针) - 品阶3, 价格2500
        public static readonly QuackItemDefinition Stim_SJ9 = new QuackItemDefinition
        {
            BaseData = new ItemData
            {
                itemId = 999018,
                order = 117,
                localizationKey = "Stim_SJ9",
                localizationDesc = "Stim_SJ9_Desc",
                weight = 0.1f,
                value = 2500,
                quality = 4,
                displayQuality = DisplayQuality.Purple,
                maxStackCount = 3,
                tags = new List<string> { "Medic", "Injector" },
                spritePath = "items/SJ9.png",
                usages = new UsageData
                {
                    actionSound = "SFX/Item/use_syringe",
                    useSound = "SFX/Item/use_syringe_success",
                    useTime = 0.5f,
                    behaviors = new List<UsageBehaviorData>
                    {
                        new FoodData { energyValue = -5f, waterValue = -10f },
                        new QuackAddBuffData { buffName = "TarkovStimulants_SJ9_Buff", chance = 1.0f }
                    }
                }
            },
            Shop = new QuackItemDefinition.ShopConfig
            {
                MerchantID = MerchantIDs.Mud,
                MaxStock = 1,
                PriceFactor = 1.0f,
                Probability = 0.7f,
                ForceUnlock = true
            }
        };

        public static readonly List<QuackItemDefinition> AllQuackItems = new List<QuackItemDefinition>
        {
            Stim_eTGc, Stim_SJ12, Stim_Propital, Stim_SJ6, Stim_MULE, Stim_Adrenaline,
            Stim_Meldonin, Stim_Morphine, Stim_L1, Stim_3bTG, Stim_Perfotoran,
            Stim_2A2bTG, Stim_P22, Stim_Obdolbos2, Stim_Trimadol, Stim_SJ1,
            Stim_Zagustin, Stim_SJ9
        };
    }
}
using System.Collections.Generic;
using Duckov.Quests;
using FastModdingLib;

namespace TarkovStimulants.Quests
{
    /// <summary>
    /// 存储所有自定义任务的静态定义
    /// </summary>
    public static class QuestDefinitions
    {
        public static readonly QuestData Quest_InjectorCase = new QuestData
        {
            ID = 999001,
            displayName = "Quest_InjectorCase_Name",
            description = "Quest_InjectorCase_Desc",
            questGiver = QuestGiverID.Mud,
            requireLevel = 1,
            requireScene = "Level_JLab_Main",
            tasks = new List<TaskData>
            {
                new TaskRequireMoney { id = 1, money = 5000 },
                new TaskKillCount { id = 2, requireAmount = 10, requireEnemy = "Cname_Raider" }
            },
            rewards = new List<RewardData>
            {
                new RewardGiveItem { id = 1, itemTypeID = 999050, amount = 1 },
                new RewardEXP { id = 2, amount = 1500 },
                new RewardUnlockItem { id = 3, itemTypeID = 999050 }
            }
        };
        
        public static readonly QuestData Quest_AutoStimCase = new QuestData
        {
            ID = 999002,
            displayName = "Quest_AutoStimCase_Name",
            description = "Quest_AutoStimCase_Desc",
            questGiver = QuestGiverID.Mud,
            requireLevel = 1,
            requireScene = "Level_HiddenWarehouse_Main",
            tasks = new List<TaskData>
            {
                new TaskRequireMoney { id = 1, money = 5000 },
                new TaskKillCount { id = 2, requireAmount = 1, requireEnemy = "Cname_Speedy" },
                new TaskKillCount { id = 3, requireAmount = 3, requireEnemy = "Cname_SpeedyChild" }
            },
            rewards = new List<RewardData>
            {
                new RewardGiveItem { id = 1, itemTypeID = 999051, amount = 1 },
                new RewardEXP { id = 2, amount = 1500 },
                new RewardUnlockItem { id = 3, itemTypeID = 999051 }
            }
        };
        
        public static readonly List<QuestData> AllQuests = new List<QuestData>
        {
            Quest_InjectorCase,
            Quest_AutoStimCase
        };
        
        // 任务关系定义 (ID, before, after)
        // 这里的 Tuple 代表 (当前任务ID, 前置ID, 后置ID)
        public static readonly List<(int id, int before, int after)> AllRelations = new List<(int, int, int)>
        {
            (999001, 314, -1),
            (999002, 63, -1)
        };
    }
}
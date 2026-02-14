using FastModdingLib;

namespace TarkovStimulants.Quests
{
    public static class QuestRegistry
    {
        public static void RegisterAll(string modId)
        {
            foreach (var questData in QuestDefinitions.AllQuests)
            {
                QuestUtils.RegisterQuest(questData, modId);
            }

            foreach (var relation in QuestDefinitions.AllRelations)
            {
                QuestUtils.AddQuestRelation(relation.id, relation.before, relation.after);
            }

            ModLogger.Log($"成功注册了 {QuestDefinitions.AllQuests.Count} 个自定义任务。");
        }

        public static void UnregisterAll(string modId)
        {
            QuestUtils.UnregisterQuestAll(modId);
            ModLogger.Log($"模组 '{modId}' 的所有任务已注销。");
        }
    }
}
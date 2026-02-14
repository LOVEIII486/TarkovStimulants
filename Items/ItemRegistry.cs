using QuackCore.Items;
using TarkovStimulants.Constants;

namespace TarkovStimulants.Items
{
    public static class ItemRegistry
    {
        public static void RegisterAll(string modPath)
        {
            foreach (var quackItem in ItemDefinitions.AllQuackItems)
            {
                QuackItemRegistry.Register(modPath, quackItem, ModConstant.ModName);
            }
            
            ModLogger.Log($"[TarkovStimulants] 成功注册了 {ItemDefinitions.AllQuackItems.Count} 个物品。");
        }
        
        public static void UnregisterAll()
        {
            QuackItemRegistry.UnregisterAll(ModConstant.ModName);
            
            ModLogger.Log($"模组所有物品已注销。");
        }
    }
}
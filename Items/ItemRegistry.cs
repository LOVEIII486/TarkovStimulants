using QuackCore.Items;
using TarkovStimulants.Constants;

namespace TarkovStimulants.Items
{
    public static class ItemRegistry
    {
        public static void RegisterAll(string dllPath)
        {
            foreach (var quackItem in ItemDefinitions.AllQuackItems)
            {
                QuackItemRegistry.Register(dllPath, quackItem, ModConstant.ModId);
            }
            ModLogger.Log($"注册了 {ItemDefinitions.AllQuackItems.Count} 个物品。");
        }
        
        public static void UnregisterAll()
        {
            QuackItemRegistry.UnregisterAll(ModConstant.ModId);
            ModLogger.Log($"注销了 {ItemDefinitions.AllQuackItems.Count} 个物品。");
        }
    }
}
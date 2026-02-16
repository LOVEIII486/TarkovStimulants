using QuackCore.BuffSystem;
using TarkovStimulants.Constants;

namespace TarkovStimulants.Buffs
{
    public static class BuffRegistry
    {
        public static void RegisterAll(string dllPath)
        {
            foreach (var buff in BuffDefinitions.AllBuffs)
            {
                QuackBuffRegistry.Register(dllPath, buff, ModConstant.ModId);
            }
            ModLogger.Log($"注册了 {BuffDefinitions.AllBuffs.Count} 个 Buff");
        }
        
        public static void UnregisterAll()
        {
            QuackBuffRegistry.UnregisterAll(ModConstant.ModId);
            ModLogger.Log($"注销了 {BuffDefinitions.AllBuffs.Count} 个 Buff");
        }
    }
}
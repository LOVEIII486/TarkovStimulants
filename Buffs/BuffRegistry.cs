using QuackCore.BuffSystem;

namespace TarkovStimulants.Buffs
{
    public static class BuffRegistry
    {
        public static void RegisterAll()
        {
            foreach (var buff in BuffDefinitions.AllBuffs)
            {
                QuackBuffRegistry.Instance.Register(buff);
            }
            ModLogger.Log($"[Buff] 成功注册了 {BuffDefinitions.AllBuffs.Count} 个 Buff");
        }
    }
}
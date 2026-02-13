using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TarkovStimulants
{
    public static class HarmonyLoader
    {
        private static Assembly _harmonyAssembly;

        public static Assembly LoadHarmony(string modRootPath)
        {
            if (_harmonyAssembly != null) return _harmonyAssembly;

            // 1. 检查环境是否已有 Harmony
            _harmonyAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name.Equals("0Harmony", StringComparison.OrdinalIgnoreCase) ||
                                     a.GetName().Name.Equals("HarmonyLib", StringComparison.OrdinalIgnoreCase));

            if (_harmonyAssembly != null) return _harmonyAssembly;

            // 2. 从当前 Mod 目录加载
            string localPath = Path.Combine(modRootPath, "0Harmony.dll");
            if (File.Exists(localPath))
            {
                try
                {
                    _harmonyAssembly = Assembly.Load(File.ReadAllBytes(localPath));
                    ModLogger.Log("成功从本地目录注入 Harmony 库");
                    return _harmonyAssembly;
                }
                catch (Exception ex) { ModLogger.LogError($"本地加载 Harmony 失败: {ex.Message}"); }
            }

            ModLogger.LogError("严重错误: 找不到 Harmony 库！");
            return null;
        }
    }
}
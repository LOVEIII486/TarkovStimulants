using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
using TarkovStimulants.Constants;

namespace TarkovStimulants
{
    internal static class ModLogger
    {
#if QUACK_DEBUG
        private const bool ShowDebugLogs = true;
#else
        private const bool ShowDebugLogs = false;
#endif

        private static string Prefix => $"[{ModConstant.ModName}]";

        /// <summary>
        /// [调试日志]
        /// </summary>
        public static void LogDebug(object message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            if (!ShowDebugLogs) return;
            string className = Path.GetFileNameWithoutExtension(sourceFilePath);
            Debug.Log($"{Prefix}[Debug][{className}.{memberName}] {message ?? "null"}");
        }

        /// <summary>
        /// [核心日志]
        /// </summary>
        public static void Log(object message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            string className = Path.GetFileNameWithoutExtension(sourceFilePath);
            Debug.Log($"{Prefix}[Info][{className}.{memberName}] {message ?? "null"}");
        }

        /// <summary>
        /// [警告日志]
        /// </summary>
        public static void LogWarning(object message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            string className = Path.GetFileNameWithoutExtension(sourceFilePath);
            Debug.LogWarning($"{Prefix}[Warn][{className}.{memberName}] {message ?? "null"}");
        }

        /// <summary>
        /// [错误日志]
        /// </summary>
        public static void LogError(object message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            string className = Path.GetFileNameWithoutExtension(sourceFilePath);
            Debug.LogError($"{Prefix}[Error][{className}.{memberName}] {message ?? "null"}");
        }

        /// <summary>
        /// [异常日志]
        /// </summary>
        public static void LogException(System.Exception ex)
        {
            Debug.LogError($"{Prefix}[Exception] 捕获到未处理的异常：");
            Debug.LogException(ex);
        }
    }
}
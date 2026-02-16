using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;
using TarkovStimulants.Constants;
using FastModdingLib;
using TarkovStimulants.Buffs;
using TarkovStimulants.Items;
using TarkovStimulants.Quests;

namespace TarkovStimulants
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        public static ModBehaviour Instance { get; private set; }

        private string _dllPath;
        private Harmony _harmonyInstance;

        private bool _isPatched = false;
        private bool _isApplicationQuitting = false;

        #region Unity Lifecycle

        private void Awake()
        {
            InitSingleton();
            InitEnvironment();
            InitLocalization();
        }

        private void OnEnable()
        {
            if (!CheckDepenndencies()) return;

            ApplyHarmonyPatches();
        }

        protected override void OnAfterSetup()
        {
            base.OnAfterSetup();

            LoadLocalization();
            RegisterAllContent();
        }

        private void OnDisable()
        {
            RemoveHarmonyPatches();

            if (_isApplicationQuitting) return;
            UnregisterAllContent();
        }

        private void OnDestroy()
        {
            ClearSingleton();
        }

        #endregion

        #region 初始化

        private void InitSingleton()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void ClearSingleton()
        {
            if (Instance == this) Instance = null;
        }

        private void InitEnvironment()
        {
            _dllPath = Assembly.GetExecutingAssembly().Location;
            Application.quitting += () => _isApplicationQuitting = true;
        }

        private void InitLocalization()
        {
            if (!CheckAssembly("FastModdingLib"))
            {
                I18n.InitI18n(_dllPath);
            }
        }

        #endregion

        #region 本地化

        private void LoadLocalization()
        {
            var currentLanguage = SodaCraft.Localizations.LocalizationManager.CurrentLanguage;
            if (I18n.localizedNames.TryGetValue(currentLanguage, out string languageFileName))
            {
                I18n.loadFileJson(_dllPath, $"/{languageFileName}");
            }
            else
            {
                ModLogger.LogWarning($"未找到当前语言 ({currentLanguage}) 的本地化配置，模组将显示原始文本。");
            }
        }

        #endregion

        #region Harmony

        private void ApplyHarmonyPatches()
        {
            if (_isPatched) return;

            try
            {
                _harmonyInstance ??= new Harmony(ModConstant.ModId);
                _harmonyInstance.PatchAll(GetType().Assembly);
                _isPatched = true;
                ModLogger.Log("Harmony 补丁注入成功。");
            }
            catch (Exception ex)
            {
                ModLogger.LogError($"Harmony 补丁注入失败: {ex.Message}");
            }
        }

        private void RemoveHarmonyPatches()
        {
            if (!_isPatched || _harmonyInstance == null) return;

            try
            {
                _harmonyInstance.UnpatchAll(ModConstant.ModId);
                _isPatched = false;
                ModLogger.Log("Harmony 补丁已成功卸载。");
            }
            catch (Exception ex)
            {
                ModLogger.LogError($"Harmony 补丁卸载异常: {ex.Message}");
            }
        }

        #endregion

        #region 注册与卸载

        private void RegisterAllContent()
        {
            BuffRegistry.RegisterAll(_dllPath);
            ItemRegistry.RegisterAll(_dllPath);
            QuestRegistry.RegisterAll(ModConstant.ModId);
        }

        private void UnregisterAllContent()
        {
            BuffRegistry.UnregisterAll();
            ItemRegistry.UnregisterAll();
            //QuestRegistry.UnregisterAll(ModConstant.ModId);
        }

        #endregion

        #region 检查前置

        private bool CheckDepenndencies()
        {
            if (HarmonyLoader.LoadHarmony(info.path) == null)
            {
                ModLogger.LogError("Harmony 加载失败！");
                enabled = false;
                return false;
            }

            if (!CheckAssembly("FastModdingLib"))
            {
                ModLogger.LogError("缺失前置库 FastModdingLib！");
                enabled = false;
                return false;
            }

            if (!CheckAssembly("QuackCore"))
            {
                ModLogger.LogError("缺失前置库 QuackCore！");
                enabled = false;
                return false;
            }

            ModLogger.Log("依赖项检查通过。");
            return true;
        }

        private bool CheckAssembly(string assemblyName)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Any(a => a.GetName().Name.Equals(assemblyName, StringComparison.OrdinalIgnoreCase));
        }

        #endregion
    }
}
using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using TarkovStimulants.Constants;
using UnityEngine.SceneManagement;
using FastModdingLib;
using TarkovStimulants.Buffs;
using TarkovStimulants.Items;

namespace TarkovStimulants
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        public static ModBehaviour Instance { get; private set; }
        
        private string _dllPath => Assembly.GetExecutingAssembly().Location;
        private Harmony _harmony;
        private bool _isPatched = false;
        private bool _hooksInitialized = false;

        #region Unity Lifecycle

        private void Awake()
        {
            InitializeSingleton();
            InitializeI18nCore();
        }

        private void OnEnable()
        {
            if (!ValidateDependencies()) return;
            
            ApplyHarmonyPatches();
            ApplySceneHooks();
        }

        protected override void OnAfterSetup()
        {
            base.OnAfterSetup();
            
            LoadLocalization();
            RegisterAllContent();
        }

        private void OnDisable()
        {
            UnregisterAllContent();
            RemoveSceneHooks();
            RemoveHarmonyPatches();
        }

        private void OnDestroy()
        {
            DisposeSingleton();
        }

        #endregion

        #region System & Initialization

        private void InitializeSingleton()
        {
            if (Instance != null) { Destroy(this); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ModLogger.Log($"{ModConstant.ModName} 初始化开始...");
        }

        private void InitializeI18nCore()
        {
            if (IsAssemblyLoaded(ModConstant.FmlAssemblyName))
            {
                I18n.InitI18n(_dllPath);
            }
        }

        private bool ValidateDependencies()
        {
            if (HarmonyLoader.LoadHarmony(info.path) != null) return true;
            
            ModLogger.LogError("缺失 Harmony 依赖，模组停用。");
            enabled = false;
            return false;
        }

        private void DisposeSingleton()
        {
            if (Instance == this) Instance = null;
        }

        #endregion

        #region 本地化

        private void LoadLocalization()
        {
            try
            {
                var lang = SodaCraft.Localizations.LocalizationManager.CurrentLanguage;
                I18n.loadFileJson(_dllPath, $"/{I18n.localizedNames[lang]}");
            }
            catch (Exception ex)
            {
                ModLogger.LogError($"本地化文件加载失败: {ex.Message}");
            }
        }

        #endregion

        #region Harmony & Scene Hooks

        private void ApplyHarmonyPatches()
        {
            if (_isPatched) return;
            try
            {
                _harmony ??= new Harmony(ModConstant.ModId);
                _harmony.PatchAll(GetType().Assembly);
                _isPatched = true;
                ModLogger.Log("Harmony 补丁已注入。");
            }
            catch (Exception ex) { ModLogger.LogError($"Patch 异常: {ex.Message}"); }
        }

        private void RemoveHarmonyPatches()
        {
            if (_isPatched && _harmony != null)
            {
                _harmony.UnpatchAll(ModConstant.ModId);
                _isPatched = false;
            }
        }

        private void ApplySceneHooks()
        {
            if (_hooksInitialized) return;
            SceneManager.sceneLoaded += OnSceneLoaded;
            _hooksInitialized = true;
        }

        private void RemoveSceneHooks()
        {
            if (_hooksInitialized)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                _hooksInitialized = false;
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            ModLogger.LogDebug($"进入场景: {scene.name}");
        }

        #endregion

        #region 注册与卸载内容

        private void RegisterAllContent()
        {
            RegisterBuffs();
            RegisterItems();
            RegisterQuests();
            ModLogger.Log($"{ModConstant.ModName} 内容已注册。");
        }

        private void UnregisterAllContent()
        {
            ItemRegistry.UnregisterAll();
            ModLogger.Log($"{ModConstant.ModName} 内容已卸载。");
        }

        private void RegisterBuffs() => BuffRegistry.RegisterAll();

        private void RegisterItems() => ItemRegistry.RegisterAll(_dllPath);

        private void RegisterQuests() { }

        #endregion

        #region 辅助函数

        private bool IsAssemblyLoaded(string name) => 
            AppDomain.CurrentDomain.GetAssemblies().Any(a => a.GetName().Name.Contains(name));

        #endregion
    }
}
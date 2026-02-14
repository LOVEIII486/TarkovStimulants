using System.Collections.Generic;
using System.Linq;
using ItemStatsSystem;
using SodaCraft.Localizations;

namespace TarkovStimulants.Items.Behavior
{
    public class AutoStimCaseBehavior : ItemStatsSystem.UsageBehavior
    {
        public override DisplaySettingsData DisplaySettings
        {
            get
            {
                int count = 0;
                var itemComponent = GetComponent<Item>();
                
                if (itemComponent != null && itemComponent.Slots != null)
                {
                    count = itemComponent.Slots.Count(s => s != null && s.Content != null);
                }

                string localizedFormat = "Item_AutoStimCase_DisplayFormat".ToPlainText();
                
                return new DisplaySettingsData 
                { 
                    display = true, 
                    description = string.Format(localizedFormat, count, 6)
                };
            }
        }

        public override bool CanBeUsed(Item item, object user)
        {
            if (item.Slots == null) return false;
            return item.Slots.Any(s => s != null && s.Content != null);
        }

        protected override void OnUse(Item item, object user)
        {
            if (!(user is CharacterMainControl character)) return;
            if (item.Slots == null) return;

            HashSet<int> injectedTypeIds = new HashSet<int>();
            int successCount = 0;

            foreach (var slot in item.Slots)
            {
                if (slot == null || slot.Content == null) continue;

                Item stimulant = slot.Content;

                if (injectedTypeIds.Contains(stimulant.TypeID))
                {
                    continue;
                }
                
                if (stimulant.IsUsable(character))
                {
                    stimulant.Use(character);
                    
                    // 手动消耗结算
                    if (stimulant.Stackable)
                    {
                        stimulant.StackCount--; 
                    }
                    else if (stimulant.UseDurability)
                    {
                        stimulant.Durability -= 1.0f;
                        if (stimulant.Durability <= 0) stimulant.StackCount = 0; 
                    }
                    injectedTypeIds.Add(stimulant.TypeID);
                    successCount++;
                }
            }

            if (successCount > 0)
            {
                ModLogger.LogDebug($"[TarkovStimulants] 自动注射盒已激活：消耗并注射了 {successCount} 支不同类型的针剂。");
            }
        }
    }
}
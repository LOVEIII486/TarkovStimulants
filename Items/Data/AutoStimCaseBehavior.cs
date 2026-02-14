using FastModdingLib;
using ItemStatsSystem;
using TarkovStimulants.Items.Behavior;

namespace TarkovStimulants.Items.Data
{
    public class AutoStimCaseData : UsageBehaviorData
    {
        public override ItemStatsSystem.UsageBehavior GetBehavior(Item item)
        {
            return item.gameObject.AddComponent<AutoStimCaseBehavior>();
        }
    }
}
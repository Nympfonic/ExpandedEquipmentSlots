using BepInEx;

namespace Arys.ExpandedEquipmentSlots
{
    [BepInPlugin("com.Arys.ExpandedEquipmentSlots", "Arys' Expanded Equipment Slots", "1.0.0")]
    public class EESPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin is loaded!");
        }
    }
}

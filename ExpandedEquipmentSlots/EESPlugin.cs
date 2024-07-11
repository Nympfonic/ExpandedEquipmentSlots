using Arys.EES.Patches;
using BepInEx;
using BepInEx.Logging;

namespace Arys.EES;

[BepInPlugin("com.Arys.ExpandedEquipmentSlots", "Arys' Expanded Equipment Slots", "1.0.0")]
public class EESPlugin : BaseUnityPlugin
{
    internal static ManualLogSource LogSource;

    private void Awake()
    {
        LogSource = Logger;

        EquipmentTabPatches.Enable();
    }
}

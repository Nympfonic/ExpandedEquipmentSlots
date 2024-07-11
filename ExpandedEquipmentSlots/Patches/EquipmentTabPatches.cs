using Arys.EES.Helpers;
using EFT.InventoryLogic;
using EFT.UI;
using EFT.UI.DragAndDrop;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Arys.EES.Patches;

internal class EquipmentTabPatches
{
    internal static void Enable()
    {
        new AddEquipmentToDict().Enable();
    }

    internal class AddEquipmentToDict : ModulePatch
    {
        private static readonly Type _targetType = typeof(EquipmentTab);

        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.DeclaredMethod(_targetType, nameof(EquipmentTab.Awake));
        }

        [PatchPostfix]
        private static void PatchPostfix(Dictionary<EquipmentSlot, SlotView> ____slotViews, SlotView ____armbandSlot)
        {
            EquipmentHelper.AddCustomEquipmentSlots(____slotViews, ____armbandSlot);
        }
    }
}

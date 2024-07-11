using Arys.EES.Wrappers;
using EFT.InventoryLogic;
using EFT.UI.DragAndDrop;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Arys.EES.Helpers;

internal static class EquipmentHelper
{
    internal static void AddCustomEquipmentSlots(IDictionary<EquipmentSlot, SlotView> equipmentSlotDict, SlotView slotToClone)
    {
        Type equipmentSlotType = typeof(EquipmentSlot);

        var beltSlot = (EquipmentSlot)Enum.Parse(equipmentSlotType, "TacticalBelt");
        var slotViewWrapper = new SlotViewWrapper(UnityObject.Instantiate(slotToClone));
        var slotView = slotViewWrapper.Value;

        // Fix transform component values after cloning
        slotView.transform.parent = slotToClone.transform.parent;
        slotView.transform.localPosition = slotToClone.transform.localPosition;
        slotView.transform.localRotation = slotToClone.transform.localRotation;

        equipmentSlotDict.Add(beltSlot, slotView);
    }
}

using Mono.Cecil;
using System.Collections.Generic;

namespace Arys.EES.PreloadPatcher
{
    public static class Patcher
    {
        public static IEnumerable<string> TargetDLLs { get; } = new[] { "Assembly-CSharp.dll" };

        public static void Patch(ref AssemblyDefinition assembly)
        {
            AddEquipmentSlots(ref assembly);
        }

        private static void AddEquipmentSlots(ref AssemblyDefinition assembly)
        {
            TypeDefinition equipmentSlot = assembly.MainModule.GetType("EFT.InventoryLogic.EquipmentSlot");

            PatcherHelper.AddEnumValue(ref equipmentSlot, "TacticalBelt");
        }
    }
}

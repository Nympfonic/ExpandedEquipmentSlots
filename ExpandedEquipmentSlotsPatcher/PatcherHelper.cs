using Mono.Cecil;

namespace Arys.ExpandedEquipmentSlotsPatcher
{
    internal static class PatcherHelper
    {
        private const FieldAttributes defaultFieldAttributes
            = FieldAttributes.Public | FieldAttributes.Static | FieldAttributes.Literal | FieldAttributes.HasDefault;

        internal static void AddEnumValues(ref TypeDefinition typeDef, params string[] names)
        {
            foreach (var name in names)
            {
                AddEnumValue(ref typeDef, name);
            }
        }

        internal static void AddEnumValue(ref TypeDefinition typeDef, string name)
        {
            var enumFields = typeDef.Fields;

            for (int i = 0; i < enumFields.Count; i++)
            {
                int currentValue = (int)enumFields[i].Constant;

                if (i + 1 == enumFields.Count)
                {
                    enumFields.Add(new FieldDefinition(name, defaultFieldAttributes, typeDef)
                    {
                        Constant = currentValue + 1
                    });

                    break;
                }

                int nextValue = (int)enumFields[i + 1].Constant;

                if (nextValue - currentValue > 1)
                {
                    enumFields.Add(new FieldDefinition(name, defaultFieldAttributes, typeDef)
                    {
                        Constant = currentValue + 1
                    });

                    break;
                }
            }
        }
    }
}

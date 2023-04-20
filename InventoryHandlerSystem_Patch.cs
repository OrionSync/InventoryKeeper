using HarmonyLib;
using Unity.Entities;
using InventoryHandlerSystem;

[HarmonyPatch(typeof(Create), "MoveInventory")]
class MoveInventoryPatch
{
    static void Prefix(Entity inventoryFrom, Entity inventoryTo, int fromStartIndex, int amountOfSlots, int toStartIndex, out ServerCommand __state)
    {
        __state = new ServerCommand
        {
            command = Command.MoveInventory,
            inventory1 = inventoryFrom,
            entityOrInventory2 = inventoryFrom,
            index1 = fromStartIndex,
            index2 = amountOfSlots,
            index3 = toStartIndex
        };
    }

    static void Postfix(ref ServerCommand __state, ref ServerCommand __result)
    {
        __result = __state;
    }
}

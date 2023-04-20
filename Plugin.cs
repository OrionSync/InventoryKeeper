using BepInEx;
using BepInEx.Unity.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using HarmonyLib.Tools;


namespace InventoryKeeper;

[BepInPlugin(GUID, NAME, VERSION)]
[BepInDependency("com.le4fless.corelib", "2.0.1")]
public class Plugin : BasePlugin
{
    public const string GUID = "com.orionsync.inventorykeeper";
    public const string NAME = "KeepInventory";
    public const string VERSION = "1.0.0";

    internal static new ManualLogSource Log;
    public override void Load()
    {
        Plugin.Log = base.Log;
        HarmonyFileLog.Enabled = true;
        var harmony = new Harmony("com.orionsync.inventorykeeper");
        harmony.PatchAll();
        // Plugin startup logic
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
}

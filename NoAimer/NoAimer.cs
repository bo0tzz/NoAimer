using BepInEx;
using HarmonyLib;

namespace NoAimer
{
    [BepInPlugin(modGuid, modName, modVersion)]
    [BepInProcess("Peglin.exe")]
    public class NoAimer : BaseUnityPlugin
    {
        private const string modGuid = "me.bo0tzz.peglinmods.noaimer";
        private const string modName = "No Aimer";
        private const string modVersion = "1.0.0.0";
        private readonly Harmony harmony = new Harmony(modGuid);

        void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo("No Aimer mod loaded");
        }
    }

    [HarmonyPatch(typeof(PredictionManager))]
    public class PredictionManagerPatches
    {
        [HarmonyPatch("SetLineRendererStatus")]
        [HarmonyPrefix]
        public static void LineRendererStatusAlwaysFalse(ref bool status)
        {
            status = false;
        }

        [HarmonyPatch("CreateBounceIndicator")]
        [HarmonyPrefix]
        public static bool NeverCreateBounceIndicator()
        {
            return false;
        }
    }
}

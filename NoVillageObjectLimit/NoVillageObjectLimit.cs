using MelonLoader;
using HarmonyLib;
using Definitions.Grid;
using Il2CppMicrosoft;
using UnityEngine;
using Mdl.Grid;

namespace NVOL
{
    public class NoVillageObjectLimit : MelonMod
    {

        public static NoVillageObjectLimit Instance;

        [HarmonyPatch(typeof(VillageObjectLimit))]
        class Patch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(VillageObjectLimit.IsGoingOverLimit))]
            static void Postfix1(ref bool __result)
            {

                __result = false;

            }

            [HarmonyPostfix]
            [HarmonyPatch(nameof(VillageObjectLimit.AllCount), MethodType.Getter)]
            static void Postfix2(ref int __result)
            {

                __result = 0;

            }

            [HarmonyPostfix]
            [HarmonyPatch(nameof(VillageObjectLimit.UniqueCount), MethodType.Getter)]
            static void Postfix3(ref int __result)
            {

                __result = 0;

            }

            [HarmonyPostfix]
            [HarmonyPatch(typeof(GridEditMode), nameof(GridEditMode.OnSystemStart))]
            static void Postfix4(GridEditMode __instance)
            {
                __instance.currentLimits.UniqueLimit = int.MaxValue;
                __instance.currentLimits.InstanceLimit = int.MaxValue;
            }


        }

    }
}

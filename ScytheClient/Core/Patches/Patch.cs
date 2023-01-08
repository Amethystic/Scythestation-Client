using HarmonyLib;
using System;

namespace ScytheStation.Core
{
    public class Patch
    {
        //Patches by Pyro
        //https://github.com/LimeAndPyro

        class PatchInstance
        {
            public static HarmonyLib.Harmony Inst = new HarmonyLib.Harmony("Patches");
        }
        public class EasyPatching
        {
            public static void EasyPatchPropertyPost(Type inputclass, string InputMethodName, Type outputclass, string outputmethodname)
            {
                PatchInstance.Inst.Patch(AccessTools.Property(inputclass, InputMethodName).GetMethod, null, new HarmonyMethod(outputclass, outputmethodname));
            }
            public static void EasyPatchPropertyPre(Type inputclass, string InputMethodName, Type outputclass, string outputmethodname)
            {
                PatchInstance.Inst.Patch(AccessTools.Property(inputclass, InputMethodName).GetMethod, new HarmonyMethod(outputclass, outputmethodname));
            }
            public static void EasyPatchMethodPre(Type inputclass, string InputMethodName, Type outputclass, string outputmethodname)
            {
                PatchInstance.Inst.Patch(inputclass.GetMethod(InputMethodName), new HarmonyMethod(AccessTools.Method(outputclass, outputmethodname)));
            }
            public static void EasyPatchMethodPost(Type inputclass, string InputMethodName, Type outputclass, string outputmethodname)
            {
                PatchInstance.Inst.Patch(inputclass.GetMethod(InputMethodName), null, new HarmonyMethod(AccessTools.Method(outputclass, outputmethodname)));
            }
        }
    }
}

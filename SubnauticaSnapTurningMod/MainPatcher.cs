using System;
using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using SMLHelper.V2.Handlers;

namespace SubnauticaSnapTurningMod
{
	// Token: 0x02000006 RID: 6
	[QModCore]
	public static class MainPatcher
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002728 File Offset: 0x00000928
		[QModPatch]
		public static void Patch()
		{
			Config.Load();
			OptionsPanelHandler.RegisterModOptions(new Options());
			Harmony harmony = new Harmony("com.ethanfischer.subnautica.snapturning.mod");
			harmony.PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}

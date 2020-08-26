using System;
using HarmonyLib;
using SMLHelper.V2.Utility;
using UnityEngine;
using UnityEngine.XR;

namespace SubnauticaSnapTurningMod
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(MainCameraControl))]
	[HarmonyPatch("Update")]
	internal class MainCameraControlPatcher
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000024D0 File Offset: 0x000006D0
		private static float SnapAngle
		{
			get
			{
				return Config.SnapAngles[Config.SnapAngleChoiceIndex];
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000024DD File Offset: 0x000006DD
		private static float SeamothSnapAngle
		{
			get
			{
				return Config.SnapAngles[Config.SeamothAngleChoiceIndex];
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000024EA File Offset: 0x000006EA
		private static float PrawnSnapAngle
		{
			get
			{
				return Config.SnapAngles[Config.PrawnAngleChoiceIndex];
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000024F7 File Offset: 0x000006F7
		private static bool IsInPrawnSuit
		{
			get
			{
				return Player.main.inExosuit;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002503 File Offset: 0x00000703
		private static bool IsInSeamoth
		{
			get
			{
				return Player.main.inSeamoth;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002510 File Offset: 0x00000710
		[HarmonyPrefix]
		public static bool Prefix()
		{
			bool flag = MainCameraControlPatcher.IsInSeamoth && !Config.EnableSeamoth;
			bool flag2 = MainCameraControlPatcher.IsInPrawnSuit && !Config.EnablePrawn;
			bool flag3 = !Config.EnableSnapTurning || flag || flag2;
			bool result;
			if (flag3)
			{
				result = true;
			}
			else
			{
				bool flag4 = GameInput.GetButtonDown(26) || KeyCodeUtils.GetKeyDown(Config.KeybindKeyRight);
				bool flag5 = GameInput.GetButtonDown(25) || KeyCodeUtils.GetKeyDown(Config.KeybindKeyLeft);
				bool buttonHeld = GameInput.GetButtonHeld(25);
				bool buttonHeld2 = GameInput.GetButtonHeld(26);
				bool flag6 = flag5 || flag4 || buttonHeld || buttonHeld2;
				bool flag7 = XRSettings.enabled && flag6;
				bool flag8 = flag7;
				if (flag8)
				{
					MainCameraControlPatcher.UpdatePlayerOrVehicleRotation(flag4, flag5);
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000025D0 File Offset: 0x000007D0
		private static void UpdatePlayerOrVehicleRotation(bool didLookRight, bool didLookLeft)
		{
			Vector3 newEulerAngles = MainCameraControlPatcher.GetNewEulerAngles(didLookRight, didLookLeft);
			bool isInSeamoth = MainCameraControlPatcher.IsInSeamoth;
			if (isInSeamoth)
			{
				Player.main.currentMountedVehicle.transform.localRotation = Quaternion.Euler(newEulerAngles);
			}
			else
			{
				bool isInPrawnSuit = MainCameraControlPatcher.IsInPrawnSuit;
				if (isInPrawnSuit)
				{
					Player.main.currentMountedVehicle.transform.localRotation = Quaternion.Euler(newEulerAngles);
				}
				else
				{
					Player.main.transform.localRotation = Quaternion.Euler(newEulerAngles);
				}
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002650 File Offset: 0x00000850
		private static Vector3 GetNewEulerAngles(bool didLookRight, bool didLookLeft)
		{
			Vector3 result = (MainCameraControlPatcher.IsInSeamoth || MainCameraControlPatcher.IsInPrawnSuit) ? Player.main.currentMountedVehicle.transform.localRotation.eulerAngles : Player.main.transform.localRotation.eulerAngles;
			float snapAngle = MainCameraControlPatcher.GetSnapAngle();
			if (didLookRight)
			{
				result.y += snapAngle;
			}
			else if (didLookLeft)
			{
				result.y -= snapAngle;
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000026E0 File Offset: 0x000008E0
		private static float GetSnapAngle()
		{
			float result = MainCameraControlPatcher.SnapAngle;
			bool isInSeamoth = MainCameraControlPatcher.IsInSeamoth;
			if (isInSeamoth)
			{
				result = MainCameraControlPatcher.SeamothSnapAngle;
			}
			else
			{
				bool isInPrawnSuit = MainCameraControlPatcher.IsInPrawnSuit;
				if (isInPrawnSuit)
				{
					result = MainCameraControlPatcher.PrawnSnapAngle;
				}
			}
			return result;
		}
	}
}

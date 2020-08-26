using System;
using SMLHelper.V2.Utility;
using UnityEngine;

// Token: 0x02000002 RID: 2
public static class Config
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static void Load()
	{
		Config.EnableSnapTurning = PlayerPrefsExtra.GetBool("SnapTurningTogglePlayerPrefKey", true);
		Config.EnableSeamoth = PlayerPrefsExtra.GetBool("SnapTurningToggleSeamoth", false);
		Config.EnablePrawn = PlayerPrefsExtra.GetBool("SnapTurningTogglePrawn", false);
		Config.SnapAngleChoiceIndex = Config.GetSnapAngleChoiceIndex(SnapType.Default);
		Config.SeamothAngleChoiceIndex = Config.GetSnapAngleChoiceIndex(SnapType.Seamoth);
		Config.PrawnAngleChoiceIndex = Config.GetSnapAngleChoiceIndex(SnapType.Prawn);
		Config.KeybindKeyLeft = PlayerPrefsExtra.GetKeyCode("SMLHelperExampleModKeybindLeft", 276);
		Config.KeybindKeyRight = PlayerPrefsExtra.GetKeyCode("SMLHelperExampleModKeybindRight", 275);
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020D8 File Offset: 0x000002D8
	private static int GetSnapAngleChoiceIndex(SnapType snapType)
	{
		int num = Config.GetChoiceIndexForSnapType(snapType);
		bool flag = num > Config.SnapAngles.Length;
		if (flag)
		{
			num = 0;
		}
		return num;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002104 File Offset: 0x00000304
	private static int GetChoiceIndexForSnapType(SnapType snapType)
	{
		int result = 0;
		bool flag = snapType == SnapType.Default;
		if (flag)
		{
			result = PlayerPrefs.GetInt("SnapAnglePlayerPrefKey", 0);
		}
		else
		{
			bool flag2 = snapType == SnapType.Seamoth;
			if (flag2)
			{
				result = PlayerPrefs.GetInt("SnapTurningToggleSeamoth", 0);
			}
			else
			{
				bool flag3 = snapType == SnapType.Prawn;
				if (flag3)
				{
					result = PlayerPrefs.GetInt("SnapTurningTogglePrawn", 0);
				}
			}
		}
		return result;
	}

	// Token: 0x04000001 RID: 1
	public static bool EnableSnapTurning = true;

	// Token: 0x04000002 RID: 2
	public static bool EnableSeamoth = false;

	// Token: 0x04000003 RID: 3
	public static bool EnablePrawn = false;

	// Token: 0x04000004 RID: 4
	public static int SnapAngleChoiceIndex = 0;

	// Token: 0x04000005 RID: 5
	public static int SeamothAngleChoiceIndex = 0;

	// Token: 0x04000006 RID: 6
	public static int PrawnAngleChoiceIndex = 0;

	// Token: 0x04000007 RID: 7
	public static float[] SnapAngles = new float[]
	{
		45f,
		90f,
		22.5f
	};

	// Token: 0x04000008 RID: 8
	public static KeyCode KeybindKeyLeft;

	// Token: 0x04000009 RID: 9
	public static KeyCode KeybindKeyRight;
}

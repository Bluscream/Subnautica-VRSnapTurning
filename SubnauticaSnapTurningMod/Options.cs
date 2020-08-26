using System;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class Options : ModOptions
{
	// Token: 0x06000005 RID: 5 RVA: 0x000021A0 File Offset: 0x000003A0
	public Options() : base("Snap Turning")
	{
		base.ToggleChanged += this.Options_ToggleChanged;
		base.ChoiceChanged += this.Options_ChoiceChanged;
		base.KeybindChanged += this.Options_KeybindChanged;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000021F4 File Offset: 0x000003F4
	public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
	{
		string id = e.Id;
		string text = id;
		if (text != null)
		{
			if (!(text == "SnapTurningId"))
			{
				if (!(text == "SeamothId"))
				{
					if (text == "PrawnId")
					{
						Config.EnablePrawn = e.Value;
						PlayerPrefsExtra.SetBool("SnapTurningTogglePrawn", e.Value);
					}
				}
				else
				{
					Config.EnableSeamoth = e.Value;
					PlayerPrefsExtra.SetBool("SnapTurningToggleSeamoth", e.Value);
				}
			}
			else
			{
				Config.EnableSnapTurning = e.Value;
				PlayerPrefsExtra.SetBool("SnapTurningTogglePlayerPrefKey", e.Value);
			}
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002294 File Offset: 0x00000494
	public void Options_ChoiceChanged(object sender, ChoiceChangedEventArgs e)
	{
		string id = e.Id;
		string text = id;
		if (text != null)
		{
			if (!(text == "SnapAngleId"))
			{
				if (!(text == "SeamothAngleId"))
				{
					if (text == "PrawnAngleId")
					{
						Config.PrawnAngleChoiceIndex = e.Index;
						PlayerPrefs.SetInt("SnapTurningTogglePrawn", e.Index);
					}
				}
				else
				{
					Config.SeamothAngleChoiceIndex = e.Index;
					PlayerPrefs.SetInt("SnapTurningToggleSeamoth", e.Index);
				}
			}
			else
			{
				Config.SnapAngleChoiceIndex = e.Index;
				PlayerPrefs.SetInt("SnapAnglePlayerPrefKey", e.Index);
			}
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002334 File Offset: 0x00000534
	public void Options_KeybindChanged(object sender, KeybindChangedEventArgs e)
	{
		bool flag = e.Id == "exampleKeybindLeft";
		if (flag)
		{
			Config.KeybindKeyLeft = e.Key;
			PlayerPrefsExtra.SetKeyCode("SMLHelperExampleModKeybindLeft", e.Key);
		}
		bool flag2 = e.Id == "exampleKeybindRight";
		if (flag2)
		{
			Config.KeybindKeyRight = e.Key;
			PlayerPrefsExtra.SetKeyCode("SMLHelperExampleModKeybindRight", e.Key);
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000023A8 File Offset: 0x000005A8
	public override void BuildModOptions()
	{
		base.AddToggleOption("SnapTurningId", "Enabled", Config.EnableSnapTurning);
		base.AddChoiceOption("SnapAngleId", "Angle", new string[]
		{
			"45",
			"90",
			"22.5"
		}, Config.SnapAngleChoiceIndex);
		bool flag = !GameInput.IsPrimaryDeviceGamepad();
		if (flag)
		{
			base.AddKeybindOption("exampleKeybindLeft", "Keyboard Left", 0, Config.KeybindKeyLeft);
			base.AddKeybindOption("exampleKeybindRight", "Keyboard Right", 0, Config.KeybindKeyRight);
		}
		base.AddToggleOption("SeamothId", "Seamoth", Config.EnableSeamoth);
		base.AddChoiceOption("SeamothAngleId", "Seamoth Angle", new string[]
		{
			"45",
			"90",
			"22.5"
		}, Config.SeamothAngleChoiceIndex);
		base.AddToggleOption("PrawnId", "Prawn Suit", Config.EnablePrawn);
		base.AddChoiceOption("PrawnAngleId", "Prawn Suit Angle", new string[]
		{
			"45",
			"90",
			"22.5"
		}, Config.PrawnAngleChoiceIndex);
	}

	// Token: 0x0400000E RID: 14
	public const string PLAYER_PREF_KEY_TOGGLE_SNAP_TURNING = "SnapTurningTogglePlayerPrefKey";

	// Token: 0x0400000F RID: 15
	public const string PLAYER_PREF_KEY_TOGGLE_SEAMOTH = "SnapTurningToggleSeamoth";

	// Token: 0x04000010 RID: 16
	public const string PLAYER_PREF_KEY_TOGGLE_PRAWN = "SnapTurningTogglePrawn";

	// Token: 0x04000011 RID: 17
	public const string PLAYER_PREF_KEY_SNAP_ANGLE = "SnapAnglePlayerPrefKey";

	// Token: 0x04000012 RID: 18
	private const string TOGGLE_CHANGED_ID_SNAP_TURNING = "SnapTurningId";

	// Token: 0x04000013 RID: 19
	private const string TOGGLE_CHANGED_ID_SEAMOTH = "SeamothId";

	// Token: 0x04000014 RID: 20
	private const string TOGGLE_CHANGED_ID_PRAWN = "PrawnId";

	// Token: 0x04000015 RID: 21
	private const string CHOICE_CHANGED_ID_SNAP_ANGLE = "SnapAngleId";

	// Token: 0x04000016 RID: 22
	private const string CHOICE_CHANGED_ID_SEAMOTH_ANGLE = "SeamothAngleId";

	// Token: 0x04000017 RID: 23
	private const string CHOICE_CHANGED_ID_PRAWN_ANGLE = "PrawnAngleId";
}

using System;
using System.Windows.Forms;

namespace ScytheStation.Components.Extensions
{
	internal class SendToClip
	{
		// Token: 0x0600004B RID: 75 RVA: 0x00003AC4 File Offset: 0x00001CC4
		public static string RandomString(int length)
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!§$%&/()=?";
			string text2 = "";
			Random random = new Random();
			for (int i = 0; i < length; i++)
			{
				text2 += text[random.Next(text.Length - 1)].ToString();
			}
			return text2;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003B14 File Offset: 0x00001D14
		internal static string GetClipboard()
		{
			if (Clipboard.ContainsText())
			{
				return Clipboard.GetText();
			}
			return "";
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003B28 File Offset: 0x00001D28
		internal static void SetClipboard(string Set)
		{
			if (Clipboard.ContainsText())
			{
				Clipboard.Clear();
				Clipboard.SetText(Set);
			}
			Clipboard.SetText(Set);
		}
	}
}

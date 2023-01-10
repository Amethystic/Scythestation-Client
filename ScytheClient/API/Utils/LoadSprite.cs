using System.IO;
using UnityEngine;

namespace ScytheStation.API.Utils
{
	public static class LoadSprite
	{
		// Token: 0x060000DE RID: 222 RVA: 0x000058F8 File Offset: 0x00003AF8
		internal static Sprite LoadSpriteFromDisk(this string path)
		{
			bool flag = string.IsNullOrEmpty(path);
			Sprite result;
			if (flag)
			{
				result = null;
			}
			else
			{
				byte[] array = File.ReadAllBytes(path);
				bool flag2 = array == null || array.Length == 0;
				if (flag2)
				{
					result = null;
				}
				else
				{
					Texture2D texture2D = new Texture2D(512, 512);
					bool flag3 = !Il2CppImageConversionManager.LoadImage(texture2D, array);
					if (flag3)
					{
						result = null;
					}
					else
					{
						Sprite sprite = Sprite.CreateSprite(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f), 100f, 0U, 0, default(Vector4), false);
						sprite.hideFlags += 32;
						result = sprite;
					}
				}
			}
			return result;
		}
	}
}
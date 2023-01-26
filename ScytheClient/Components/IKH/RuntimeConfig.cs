using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Components.IKH
{
	public class RuntimeConfig
	{
		[Obfuscation(Exclude = false)]
		public static bool tPose;
		public static bool noNeck;
		public static bool noChest;
		public static bool twist;
		public static bool leftArm;
		public static bool rightArm;
	}
}

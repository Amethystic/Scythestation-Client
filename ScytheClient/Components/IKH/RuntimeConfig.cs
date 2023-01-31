using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Components.IKH
{
	internal class RuntimeConfig
	{
		[Obfuscation(Exclude = false)]
		public static bool tPose;
	}
}

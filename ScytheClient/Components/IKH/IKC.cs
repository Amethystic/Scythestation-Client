using System;
using RootMotion.FinalIK;
using UnityEngine;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Components.IKH
{
	[Obfuscation(Exclude = true)]
	public class IKC: MonoBehaviour
	{
		public IKC(IntPtr ptr) : base(ptr) {  }
		private void Update()
		{
			if (VRCPlayer.field_Internal_Static_VRCPlayer_0 == null)
			{
				return;
			}
			if (vrik == null)
			{
				vrik = base.gameObject.GetComponentInChildren<VRIK>();
			}
			if (RuntimeConfig.tPose)
			{
				vrik.animator.enabled = false;
			}
		} private VRIK vrik;
	}
}

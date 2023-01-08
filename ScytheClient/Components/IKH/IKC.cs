using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace ScytheStation.Components.IKH
{
	public class IKC: MonoBehaviour
	{
		public IKC(IntPtr ptr) : base(ptr)
		{
		}
		private void Update()
		{
			if (VRCPlayer.field_Internal_Static_VRCPlayer_0 == null)
			{
				return;
			}
			if (this.vrik == null)
			{
				this.vrik = base.gameObject.GetComponentInChildren<VRIK>();
			}
			if (RuntimeConfig.tPose)
			{
				this.vrik.animator.enabled = false;
			}
			if (RuntimeConfig.twist)
			{
				this.vrik.fixTransforms = false;
				this.vrik.animator.enabled = false;
			}
			if (RuntimeConfig.noNeck)
			{
				this.vrik.solver.hasNeck = false;
			}
			if (RuntimeConfig.noChest)
			{
				this.vrik.solver.hasChest = false;
			}
			if (RuntimeConfig.leftArm)
			{
				this.vrik.solver.leftArm.positionWeight = 1f;
			}
			if (RuntimeConfig.rightArm)
			{
				this.vrik.solver.rightArm.positionWeight = 1f;
			}
		}
		private VRIK vrik;
	}
}

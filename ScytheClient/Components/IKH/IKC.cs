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
			if (vrik == null)
			{
				vrik = base.gameObject.GetComponentInChildren<VRIK>();
			}
			if (RuntimeConfig.tPose)
			{
				vrik.animator.enabled = false;
			}
			if (RuntimeConfig.twist)
			{
				vrik.fixTransforms = false;
				vrik.animator.enabled = false;
			}
			if (RuntimeConfig.noNeck)
			{
				vrik.solver.hasNeck = false;
			}
			if (RuntimeConfig.noChest)
			{
				vrik.solver.hasChest = false;
			}
			if (RuntimeConfig.leftArm)
			{
				vrik.solver.leftArm.positionWeight = 1f;
			}
			if (RuntimeConfig.rightArm)
			{
				vrik.solver.rightArm.positionWeight = 1f;
			}
		}
		private VRIK vrik;
	}
}

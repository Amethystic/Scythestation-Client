using UnityEngine;
using VRC.SDKBase;
using ScytheStation.Components.Extensions;
using ScytheStation.Components;
using VRC;

namespace ScytheStation.Functions
{
    internal class Movements
    {
        public static void SpeedRunOn()
        {
            Networking.LocalPlayer.SetWalkSpeed(Networking.LocalPlayer.GetWalkSpeed() * Movements.NewSpeedValue);
            Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() * Movements.NewSpeedValue);
            Networking.LocalPlayer.SetStrafeSpeed(Networking.LocalPlayer.GetStrafeSpeed() * Movements.NewSpeedValue);
        }
        public static void SpeedRunOff()
        {
            Networking.LocalPlayer.SetWalkSpeed(2f);
            Networking.LocalPlayer.SetRunSpeed(4f);
            Networking.LocalPlayer.SetStrafeSpeed(2f);
        }
		public static void FlyOn()
        {
			MainSettings.flytoggle = true;
			VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<CharacterController>().enabled = false;
			Movements.origGrav = Physics.gravity;
			Physics.gravity = Vector3.zero;
		}
		public static void FlyOff()
		{
            MainSettings.flytoggle = false;
			VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<CharacterController>().enabled = true;
            Physics.gravity = Movements.origGrav;
        }
        public static void OnUpdate()
        {
            if (MainSettings.flytoggle)
            {
                if (RoomManager.field_Internal_Static_ApiWorld_0 == null)
                {
                    return;
                }
                if (Movements.LocalPlayer == null || Movements.CameraTransform == null)
                {
                    Movements.LocalPlayer = PlayerExtensions.LocalPlayer;
                    Movements.CameraTransform = Camera.main.transform;
                }
                if (Input.GetAxis("Vertical") != 10f)
                {
                    Movements.LocalPlayer.transform.position += Movements.CameraTransform.forward * 7f * Time.deltaTime * Input.GetAxis("Vertical");
                }
                if (Input.GetAxis("Horizontal") != 10f)
                {
                    Movements.LocalPlayer.transform.position += Movements.CameraTransform.right * 7f * Time.deltaTime * Input.GetAxis("Horizontal");
                }
                if (Input.GetKey(KeyCode.E))
                {
                    Movements.LocalPlayer.transform.position += Movements.CameraTransform.up * 7f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    Movements.LocalPlayer.transform.position += Movements.CameraTransform.up * (float)(-(float)Movements.speed) * 2f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    Movements.LocalPlayer.transform.position += Movements.CameraTransform.right * (float)(-(float)Movements.speed) * 2f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    Movements.LocalPlayer.transform.position += Movements.CameraTransform.right * 7f * Time.deltaTime;
                }
            }
        }
        public static void JumpingShitOn()
        {
            MainSettings.Idek = true;
        }
        public static void JumpingShitOff()
        {
            MainSettings.Idek = false;
        }
        public static void ClickTPOn()
        {
            MainSettings.ClickTP = true;
        }
        public static void ClickTPOff()
        {
            MainSettings.ClickTP = false;
        }
        public static void JumpingShit()
        {
            if (MainSettings.Idek == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Vector3 velocity = Networking.LocalPlayer.GetVelocity();
                    velocity.y = Networking.LocalPlayer.GetJumpImpulse();
                    Networking.LocalPlayer.SetVelocity(velocity);
                }
                else if (Input.GetButtonDown("Jump"))
                {
                    Vector3 velocity = Networking.LocalPlayer.GetVelocity();
                    velocity.y = Networking.LocalPlayer.GetJumpImpulse();
                    Networking.LocalPlayer.SetVelocity(velocity);
                }
            }
            else { }
        }
        public static void ClickTPHandle()
        {
            if (MainSettings.ClickTP == true)
            {
                if (RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
                {
                    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                        if (Physics.Raycast(ray, out RaycastHit raycastHit)) VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = raycastHit.point;
                    }
                }
            }
            else { }
        }

        public static float NewSpeedValue = 10f;
		public static int speed = 5;
		private static Player LocalPlayer;
		private static Transform CameraTransform;
		public static float FlySpeed = 25f;
		public static bool IsRunning = false;
		public static Vector3 origGrav = default(Vector3);
	}
}

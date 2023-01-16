using UnityEngine;
using VRC.SDKBase;
using ScytheStation.Components;
using VRC;

namespace ScytheStation.Functions
{
    internal class Movements
    {
        // Fly = Replaced
        // Speedhack = Replaced n simpler
        public static float NewSpeedValue = 10f;
        public static int speed = 25;
        public static float FlySpeed = 25f;
        public static bool IsRunning = false;
        public static Vector3 origGrav = default(Vector3);
        public static void SpeedRunToggle()
        {
            if (MainSettings.Run == true)
            {
                MainSettings.Run = true;
                Networking.LocalPlayer.SetWalkSpeed(NewSpeedValue);
                Networking.LocalPlayer.SetRunSpeed(speed);
                Networking.LocalPlayer.SetStrafeSpeed(speed);
            }
            else if (MainSettings.Run == false)
            {
                MainSettings.Run = false;
                Networking.LocalPlayer.SetWalkSpeed(2f);
                Networking.LocalPlayer.SetRunSpeed(4f);
                Networking.LocalPlayer.SetStrafeSpeed(2f);
            }
        }
		public static void FlyOn()
        {
            MainSettings.flytoggle = true;

            if (MainSettings.flytoggle == true)
            {
                VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<CharacterController>().enabled = false;
                origGrav = Physics.gravity;
                Physics.gravity = Vector3.zero;
            }
        }
        public static void FlyOff()
        {
            MainSettings.flytoggle = false;

            if (MainSettings.flytoggle == false)
            {
                VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<CharacterController>().enabled = true;
                Physics.gravity = origGrav;
            }
        }
        public static void OnUpdate()
        {
            if (MainSettings.flytoggle)
            {
                if (Player.prop_Player_0.field_Private_VRCPlayerApi_0.IsUserInVR())
                {
                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f)
                    {
                        Player.prop_Player_0.transform.position -= VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.up * FlySpeed;
                    }
                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f)
                    {
                        Player.prop_Player_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.up * FlySpeed;
                    }
                    if (Input.GetAxis("Vertical") != 0f)
                    {
                        Player.prop_Player_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.forward * (FlySpeed * Input.GetAxis("Vertical"));
                    }
                    if (Input.GetAxis("Horizontal") != 0f)
                    {
                        Player.prop_Player_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.right * (FlySpeed * Input.GetAxis("Horizontal"));
                    }
                    Networking.LocalPlayer.SetVelocity(Vector3.zero);
                }
                else
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        Player.prop_Player_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.forward * FlySpeed;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        Player.prop_Player_0.transform.position -= VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.forward * FlySpeed;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        Player.prop_Player_0.transform.position -= VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.right * (FlySpeed);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        Player.prop_Player_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.right * (FlySpeed);
                    }
                    if (Input.GetKey(KeyCode.Q))
                    {
                        Player.prop_Player_0.transform.position -= VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.up * (FlySpeed);
                    }
                    if (Input.GetKey(KeyCode.E))
                    {
                        Player.prop_Player_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.up * (FlySpeed);
                    }
                    Networking.LocalPlayer.SetVelocity(Vector3.zero);
                } return;
            }
        }
        public static void ClickTPToggle()
        {
            MainSettings.ClickTP = true;

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
            } else { MainSettings.ClickTP = false; }
        }
	}
}

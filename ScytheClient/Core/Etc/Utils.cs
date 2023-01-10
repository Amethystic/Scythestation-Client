using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using ScytheStation.Core.FileManager;

namespace ScytheStation.Core.Etc
{
    internal class Utils
	{
		public static IEnumerator PlayAudio(string filename)
		{
			Etc.B();
			Utils.isSent = false;
			UnityWebRequest uwr = UnityWebRequest.Get("file://" + Path.Combine(Environment.CurrentDirectory, $"{Directories.Folder}\\Misc\\Loading\\Load.ogg" + filename + ".ogg"));
			uwr.SendWebRequest();
			while (!uwr.isDone)
			{
				yield return null;
			}
			AudioClip audiofile = WebRequestWWW.InternalCreateAudioClipUsingDH(uwr.downloadHandler, uwr.url, false, false, 0);
			audiofile.hideFlags += 32;
			while (Utils.audioSource == null && !Utils.isSent)
            {
                GameObject gameObject = GameObject.Find("LoadingBackground_TealGradient_Music/LoadingSound");
				GameObject gameObject2 = GameObject.Find("MenuContent/Popups/LoadingPopup/LoadingSound");
				Utils.audioSource = ((gameObject != null) ? gameObject.GetComponent<AudioSource>() : null);
				Utils.audioSource = ((gameObject2 != null) ? gameObject2.GetComponent<AudioSource>() : null);
				AudioSource qm = GameObject.Find("Canvas_QuickMenu(Clone)").gameObject.AddComponent<AudioSource>();
				qm.playOnAwake = true;
				qm.clip = audiofile;
				qm.volume = 1f;
				qm.enabled = true;
				qm.Play();
				Utils.isSent = true;
				yield return null;
				qm = null;
			}
			yield break;
        }
        public static bool isSent;
		public static AudioSource audioSource;
	}
}

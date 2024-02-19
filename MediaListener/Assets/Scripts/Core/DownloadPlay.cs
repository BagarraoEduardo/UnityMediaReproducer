using System;
using System.Net.Http;
using Cysharp.Threading.Tasks;
using MediaListener.Integration.MediaAPI;
using MediaListener.Integration.MediaAPI.Interfaces;
using UnityEngine;

namespace MediaListener.Core
{
	public class DownloadPlay : MonoBehaviour
	{

		private IClientClient _clientClient;

		[SerializeField]
		private AudioSource _audioSource;

		void Start()
		{
			_clientClient = new ClientClient();
		}

		async void OnTriggerEnter(Collider other)
		{
			try
			{
				if(_audioSource.clip == null)
				{
					var audioClip = await _clientClient.DownloadAudio(this.GetCancellationTokenOnDestroy());
					
					if(audioClip.Success)
					{
						_audioSource.clip = audioClip.audioClip;
					}
				}

				_audioSource.Play();

				Debug.Log("Download - Collision Start");

			}
			catch(Exception exception)
			{
				Debug.LogException(exception, this);
			}
		}
	
		void OnTriggerStay(Collider other)
		{
			Debug.Log("Download - Collision Stay");
		}
	
		void OnTriggerExit(Collider other)
		{
			_audioSource.Stop();
		}
	}
}

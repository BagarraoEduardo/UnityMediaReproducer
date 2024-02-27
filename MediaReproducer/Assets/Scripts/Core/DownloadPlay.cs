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
				Debug.Log("Download - Collision Enter");

				if(_audioSource.clip == null)
				{
					var audioClip = await _clientClient.DownloadAudio(this.GetCancellationTokenOnDestroy());
					
					if(audioClip.Success)
					{
						_audioSource.clip = audioClip.audioClip;
					}
				}

				_audioSource.Play();
			}
			catch(Exception exception)
			{
				Debug.LogException(exception, this);
			}
		}
	
		void OnTriggerExit(Collider other)
		{
			Debug.Log("Download - Collision Exit");

			_audioSource.Stop();
		}
	}
}

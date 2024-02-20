using System;
using Cysharp.Threading.Tasks;
using MediaListener.Integration.MediaAPI;
using MediaListener.Integration.MediaAPI.Interfaces;
using UnityEngine;

namespace MediaListener.Core
{
	
	public class StreamPlay : MonoBehaviour
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
			Debug.Log("Stream - Collision Enter");

			try
			{

				if(_audioSource.clip == null)
				{
					var audioClip = await _clientClient.StreamAudio(this.GetCancellationTokenOnDestroy());
					
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
			Debug.Log("Stream - Collision Exit");
		}
	}
}
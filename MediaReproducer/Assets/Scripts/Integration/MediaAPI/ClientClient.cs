using System;
using System.Collections;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using MediaListener.Integration.MediaAPI.Interfaces;
using MediaListener.Settings;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace MediaListener.Integration.MediaAPI
{
    public class ClientClient : IClientClient
    {
        private readonly MediaApiSettings _settings;

        public ClientClient()
        {
            try
            {
                var filePath = $"{Application.dataPath}/StreamingAssets/{typeof(MediaApiSettings).Name}.json";

                var jsonString = File.ReadAllText(filePath);

                _settings = JsonConvert.DeserializeObject<MediaApiSettings>(jsonString);
            }
            catch(Exception exception)
            {
                Debug.LogException(exception);
            }
        }
        
        public async UniTask<(bool Success, AudioClip audioClip)> DownloadAudio(CancellationToken cancellationToken)
        {
            (bool Success, AudioClip audioClip) response = (false, null);

            try
            {
                var unityWebRequest = await UnityWebRequestMultimedia
                    .GetAudioClip($"{_settings.Url}{_settings.Audio}", AudioType.WAV)
                    .SendWebRequest()
                    .WithCancellation(cancellationToken);

                var hasError = 
                    unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
                    unityWebRequest.result == UnityWebRequest.Result.DataProcessingError ||
                    unityWebRequest.result == UnityWebRequest.Result.ProtocolError;

                if(!hasError)
                {
                    response.audioClip = DownloadHandlerAudioClip.GetContent(unityWebRequest);
                    response.Success = true;
                }
                else
                {
                    Debug.LogError($"An error ocurred while downloading the audio file from MediaAPI [requestResult={unityWebRequest.result}].");
                }
            }
            catch(Exception exception)
            {
                Debug.LogException(exception);
            }

            return response;
        }

        public async UniTask<(bool Success, AudioClip audioClip)> StreamAudio(CancellationToken cancellationToken)
        {
            (bool Success, AudioClip audioClip) response = (false, null);

            try
            {
                var unityWebRequest = UnityWebRequestMultimedia
                    .GetAudioClip($"{_settings.Url}{_settings.Audio}", AudioType.WAV);
                
                var downloadHandler = unityWebRequest.downloadHandler as DownloadHandlerAudioClip;
                    downloadHandler.streamAudio = true;

                await unityWebRequest
                    .SendWebRequest()
                    .WithCancellation(cancellationToken);

                var hasError = 
                    unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
                    unityWebRequest.result == UnityWebRequest.Result.DataProcessingError ||
                    unityWebRequest.result == UnityWebRequest.Result.ProtocolError;

                if(!hasError)
                {
                    while(!downloadHandler.isDone)
                    {
                        await UniTask.Yield();
                    }

                    response.audioClip = downloadHandler.audioClip;
                    response.Success = true;
                }
                else
                {
                    Debug.LogError($"An error ocurred while streaming the audio file from MediaAPI [requestResult={unityWebRequest.result}].");
                }
            }
            catch(Exception exception)
            {
                Debug.LogException(exception);
            }

            return response;
        }
    }
}

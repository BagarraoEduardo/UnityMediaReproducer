using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MediaListener.Integration.MediaAPI.Interfaces
{
    public interface IClientClient
    {
        UniTask<(bool Success, AudioClip audioClip)> DownloadAudio(CancellationToken cancellationToken);
        UniTask<(bool Success, AudioClip audioClip)> StreamAudio(CancellationToken cancellationToken);
    }
}

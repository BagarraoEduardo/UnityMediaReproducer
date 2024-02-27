using System;
using MediaListener.Settings.Base;

namespace MediaListener.Settings
{
    [Serializable]
    public class MediaApiSettings : BaseUrlSettings
    {
        public string Audio { get; set; }
    }
}


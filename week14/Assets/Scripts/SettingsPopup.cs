using System.Collections;
using System;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    public void OnSoundToggle()
    {
        Managers.Audio.SoundMute = !Managers.Audio.SoundMute;
    }
    public void OnSoundValue(float volume)
    {
        Managers.Audio.soundVolumn = volume;
    }
}

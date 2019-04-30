using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
        Managers.Audio.PlaySound(sound);
    }

    public void OnSoundValue(float volume)
    {
        Managers.Audio.soundVolumn = volume;
    }
}

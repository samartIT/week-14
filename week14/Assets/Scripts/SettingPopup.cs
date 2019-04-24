using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : MonoBehaviour
{
    [SerializeField] private AudioClip sound;

    public void OnPlayMusic(int selector) {
        Managers.Audio.PlaySound(sound);
        switch (selector) {
        case 1:
            Managers.Audio.PlayIntroMusic();
            break;
        case 2:
            Managers.Audio.PlayLeveloMusic();
            break;
        default:
                Managers.Audio.StopMusic();
                break;
        }
    }
    public void onTrigger() {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
        Managers.Audio.PlaySound(sound);
    }
    public void OnSoundToggle() {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
    }

    public void OnSoundValue(float volume) {
        Managers.Audio.soundVolumn = volume;
    }

    public void OnMusicToggle() {
        Managers.Audio.musicMute = !Managers.Audio.musicMute;
        Managers.Audio.PlaySound(sound);
    }

    public void OnMusicValue(float volume) {
        Managers.Audio.musicVolume = volume;
    }
}

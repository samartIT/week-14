﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : MonoBehaviour
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

    public void OnPlayMusic(int selector)
    {
        Managers.Audio.PlaySound(sound);
        switch (selector)
        {
            case 1:
                Managers.Audio.PlayIntroMusic();
                break;
            case 2:
                Managers.Audio.PlayLevelMusic();
                break;
            default:
                Managers.Audio.StopMusic();
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

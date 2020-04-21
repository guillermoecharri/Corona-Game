using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] private SoundType soundType;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameObject.GetComponent<Slider>().value = audioManager.GetUserVolume(soundType);
    }

    public void AdjustVolumeUI(float volume)
    {
        audioManager.AdjustVolume(SoundType.UI, volume);
    }

    public void AdjustVolumeMusic(float volume)
    {
        audioManager.AdjustVolume(SoundType.Music, volume);
    }

    public void AdjustVolumeGame(float volume)
    {
        audioManager.AdjustVolume(SoundType.Game, volume);
    }

}

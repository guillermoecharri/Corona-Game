using UnityEngine;
using UnityEngine.Audio;

[System.Serializable] public enum SoundType { UI, Music, Game }

[System.Serializable]
public class Sound
{
    [SerializeField] private string name;
    
    [SerializeField] SoundType soundType;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] [Range(0f, 1f)] private float modifierVolume; //used to adjust default volume of the clip (incase its too loud/soft)
    [SerializeField] [Range(0f, 1f)] private float userVolume = 0.5f; //users set volume for the type of clip
    [SerializeField] private bool loop;
    private AudioSource audioSource;

    public string GetName()
    {
        return name;
    }

    public SoundType GetSoundType()
    {
        return soundType;
    }

    public AudioClip GetAudioClip()
    {
        return audioClip;
    }

    public void SetAudioSource(AudioSource audioSource)
    {
        this.audioSource = audioSource;
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }

    public void SetupAudioSource()
    {
        audioSource.clip = audioClip;
        audioSource.volume = modifierVolume * userVolume;
        audioSource.loop = loop;
    }

    public void ChangeVolume(float userVolume)
    {
        audioSource.volume = modifierVolume * userVolume;
    }
}

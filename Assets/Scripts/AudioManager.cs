using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    private static AudioManager instance;
    private float userVolumeUI = 0.5f;
    private float userVolumeGame = 0.5f;
    private float userVolumeMusic = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        //use singleton pattern to ensure there is only one audio manager
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); //allows AudioManager to persist between scenes to prevent breaks in looped tracks

        //set up audio sources for all sounds
        for(int i = 0; i < sounds.Length; i++)
        {
            sounds[i].SetAudioSource(gameObject.AddComponent<AudioSource>());
            sounds[i].SetupAudioSource();
        }

        //play the main theme
        Play("Main Theme");
    }

    public void Play (string name)
    {
        //find the sound
        Sound sound = null;
        for(int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].GetName() == name)
            {
                sound = sounds[i];
            }
        }

        //ensure the sound exist
        if(sound == null)
        {
            Debug.LogWarning("Sound with name: " + name + " not found.");
        }
        else //play the sound
        {
            sound.GetAudioSource().Play();
        }
    }

    public void AdjustVolume (SoundType soundType, float volume)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].GetSoundType() == soundType)
            {
                sounds[i].ChangeVolume(volume);
            }
        }

        if(soundType == SoundType.Game)
        {
            userVolumeGame = volume;
        }
        else if (soundType == SoundType.UI)
        {
            userVolumeUI = volume;
        }
        else if (soundType == SoundType.Music)
        {
            userVolumeMusic = volume;
        }
    }

    public void Mute(SoundType soundType)
    {
        AdjustVolume(soundType, 0f);
    }

    public float GetUserVolume(SoundType soundType)
    {
        if (soundType == SoundType.Game)
        {
            return userVolumeGame;
        }
        else if (soundType == SoundType.Music)
        {
            return userVolumeMusic;
        }
        else //soundType == SoundType.UI
        {
            return userVolumeUI;
        }
    }

}

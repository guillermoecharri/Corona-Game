using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    private static AudioManager instance;

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
    }

    public void AdjustVolumeUI (float volume) //work around function since unity buttons cannot pass enums or multiple arguments
    {
        AdjustVolume(SoundType.UI, volume);
    }

    public void AdjustVolumeMusic (float volume)
    {
        AdjustVolume(SoundType.Music, volume);
    }

    public void AdjustVolumeGame(float volume)
    {
        AdjustVolume(SoundType.Game, volume);
    }

    public void Mute(SoundType soundType)
    {
        AdjustVolume(soundType, 0f);
    }
}

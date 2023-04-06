using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    public Sound[] sounds;
    [SerializeField]
    private int AmountOfSourcePool;
    [SerializeField]
    private GameObject AudioSourcePrefab;
    string[] soundsNames;
    ObjectPool<AudioSourceController> AudioSourcePool;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Init();
        }
        else
            Destroy(gameObject);
    }
    private void Init()
    {
        AudioSourcePool = new ObjectPool<AudioSourceController>(AmountOfSourcePool, AudioSourcePrefab);
        soundsNames = new string[sounds.Length];
        for (int i = 0; i < sounds.Length; i++)
        {
            soundsNames[i] = sounds[i].name;
        }
    }

    public void ChangeActivity(string soundName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {

            if (sounds[i].name == soundName)
            {
                sounds[i].changeActivity();

                return;
            }
        }

        //no sound with _name
        Debug.LogWarning("AudioComponent: Sound not found in list" + soundName);

    }

    public void PlaySound(string soundName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {

            if (sounds[i].name == soundName)
            {
                if (!sounds[i].checkActivity())
                    return;

                var Source = AudioSourcePool.GetPooledObject();
                sounds[i].SetSource(Source.GetAudioSource());
                sounds[i].Play();
                Source.StartTimer(AudioSourcePool);
                return;
            }
        }

        //no sound with _name
        Debug.LogWarning("AudioComponent: Sound not found in list" + soundName);

    }

    public void PlayMusic(string musicName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == musicName)
            {
                if (!sounds[i].checkActivity())
                    return;

                sounds[i].SetSource(AudioSourcePool.GetPooledObject().GetAudioSource());
                sounds[i].Play();
                sounds[i].source.loop = true;

                return;
            }
        }
    }

    public void AudioControl(float audioVolume)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (audioVolume == 0f)
            {
                sounds[i].Stop();
            }

            else
            {
                sounds[i].source.volume = audioVolume;
            }

        }
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;
    private bool isActive;

    public void changeActivity()
    {
        isActive = !isActive;
    }
    
    public bool checkActivity()
    {
        return isActive;
    }
    public void SetSource(AudioSource audioSource)
    {
        source = audioSource;
        source.clip = clip;
        source.volume = 0.2f;
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
        source.gameObject.GetComponent<IPoolable>().DeActivate();
    }


}
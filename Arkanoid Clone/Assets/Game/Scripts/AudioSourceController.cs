using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioSourceController : MonoBehaviour, IPoolable
{
    private AudioSource Audio;
    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }

    public AudioSource GetAudioSource()
    {
        return Audio;
    }

    public void StartTimer(ObjectPool<AudioSourceController> pool)
    {
        float time = Audio.clip.length;
        StartCoroutine(SoundFinished(time,pool));
    }
    private IEnumerator SoundFinished(float Time,ObjectPool<AudioSourceController> pool)
    {
        yield return new WaitForSeconds(Time);
        pool.ObjectDeactivated(this);
        DeActivate();
    }
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleController : MonoBehaviour, IPoolable
{
    private ParticleSystem _particle;
    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _particle.Stop();
    }
    public void StartDeactiveTimer(ObjectPool<ParticleController> pool)
    {
        StartCoroutine(ParticleFinished(_particle.duration, pool));
    }
    public void Activate()
    {
        _particle.Play();
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        _particle.Stop();
        gameObject.SetActive(false);
    }
    private IEnumerator ParticleFinished(float value,ObjectPool<ParticleController> pool)
    {
        yield return new WaitForSeconds(value);
        pool.ObjectDeactivated(this);
        DeActivate();
    }
}

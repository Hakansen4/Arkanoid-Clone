using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;
using Events.Others;
using System;

public class BallVfxController
{
    private ObjectPool<SparkController> _ParticlePool;
    private Transform transform;
    bool isActive;
    public BallVfxController(Transform transform,int ParticlePoolSize,GameObject particleObject)
    {
        this.transform = transform;
        _ParticlePool = new ObjectPool<SparkController>(ParticlePoolSize, particleObject);
    }
    public void SubEvents()
    {
        EventBus<EV_BallHitVfx>.AddListener(ActivateEffect);
        EventBus<EV_BallCollide>.AddListener(StartEffect);
    }
    public void UnSubEvents()
    {
        EventBus<EV_BallHitVfx>.RemoveListener(ActivateEffect);
        EventBus<EV_BallCollide>.RemoveListener(StartEffect);
    }

    private void ActivateEffect(object sender, EV_BallHitVfx @event)
    {
        isActive = !isActive;
    }

    private void StartEffect(object sender, EV_BallCollide @event)
    {
        if (!isActive)
            return;

        var effect = _ParticlePool.GetPooledObject();
        effect.gameObject.transform.position = transform.position;
        effect.StartDeactiveTimer(_ParticlePool);
    }
}

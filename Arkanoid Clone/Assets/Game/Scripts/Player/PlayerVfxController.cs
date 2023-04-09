using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Others;
using Events.Features;
using System;

public class PlayerVfxController
{
    private ObjectPool<ParticleController> _Particles;
    private Transform transform;
    private bool confettiIsActive;
    public PlayerVfxController(Transform transform, GameObject Confetti)
    {
        this.transform = transform;
        _Particles = new ObjectPool<ParticleController>(2, Confetti);
    }

    public void SubEvents()
    {
        EventBus<EV_PlayerConfetti>.AddListener(ConfettiActivity);
        EventBus<EV_BallPaddleCollide>.AddListener(StartConfetti);
    }
    public void UnSubEvents()
    {
        EventBus<EV_PlayerConfetti>.RemoveListener(ConfettiActivity);
        EventBus<EV_BallPaddleCollide>.RemoveListener(StartConfetti);
    }

    private void ConfettiActivity(object sender, EV_PlayerConfetti @event)
    {
        confettiIsActive = !confettiIsActive;
    }

    private void StartConfetti(object sender, EV_BallPaddleCollide @event)
    {
        if (!confettiIsActive)
            return;

        var effect = _Particles.GetPooledObject();
        effect.gameObject.transform.position = transform.position + Vector3.up/2;
        effect.StartDeactiveTimer(_Particles);
    }
}

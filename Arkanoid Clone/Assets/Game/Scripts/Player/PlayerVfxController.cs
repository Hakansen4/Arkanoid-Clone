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
    private Transform LeftEye;
    private Transform RightEye;
    private bool confettiIsActive;
    private GameObject Mouth;
    public PlayerVfxController(Transform transform, GameObject Confetti, Transform LeftEye,Transform RightEye, GameObject Mouth)
    {
        this.Mouth = Mouth;
        this.RightEye = RightEye;
        this.LeftEye = LeftEye;
        this.transform = transform;
        _Particles = new ObjectPool<ParticleController>(2, Confetti);
    }

    public void SubEvents()
    {
        EventBus<EV_PlayerConfetti>.AddListener(ConfettiActivity);
        EventBus<EV_BallPaddleCollide>.AddListener(StartConfetti);
        EventBus<EV_PlayerEyeActive>.AddListener(EyeActivity);
        EventBus<EV_EyeValues>.AddListener(EyeValues);
        EventBus<EV_ActivateMouth>.AddListener(ActivateMouth);
    }
    public void UnSubEvents()
    {
        EventBus<EV_PlayerConfetti>.RemoveListener(ConfettiActivity);
        EventBus<EV_BallPaddleCollide>.RemoveListener(StartConfetti);
        EventBus<EV_PlayerEyeActive>.AddListener(EyeActivity);
        EventBus<EV_EyeValues>.RemoveListener(EyeValues);
        EventBus<EV_ActivateMouth>.RemoveListener(ActivateMouth);
    }

    private void ActivateMouth(object sender, EV_ActivateMouth @event)
    {
        if (Mouth.active)
            Mouth.SetActive(false);
        else
            Mouth.SetActive(true);
    }

    private void EyeValues(object sender, EV_EyeValues @event)
    {
        if (!LeftEye.gameObject.active)
            return;

        ResetEyeValues();
        LeftEye.localScale += new Vector3(@event.EyeScale, @event.EyeScale, 0);
        RightEye.localScale += new Vector3(@event.EyeScale, @event.EyeScale, 0);
        LeftEye.localPosition += new Vector3(@event.EyePos, 0, 0);
        RightEye.localPosition -= new Vector3(@event.EyePos, 0, 0);
    }
    private void ResetEyeValues()
    {
        LeftEye.localScale = new Vector3(0.2f, 0.2f, 1);
        RightEye.localScale = new Vector3(0.2f, 0.2f, 1);
        LeftEye.localPosition = new Vector3(-0.5f, 0, 0);
        RightEye.localPosition = new Vector3(0.5f, 0, 0);
    }

    private void EyeActivity(object sender, EV_PlayerEyeActive @event)
    {
        if(LeftEye.gameObject.active)
        {
            LeftEye.gameObject.SetActive(false);
            RightEye.gameObject.SetActive(false);
        }
        else
        {
            LeftEye.gameObject.SetActive(true);
            RightEye.gameObject.SetActive(true);
        }
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

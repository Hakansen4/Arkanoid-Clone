using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using DG.Tweening;
using System;

public class ShakeFeature<EventActivate>
{
    Transform transform;
    private Vector3 StartingPos;
    private float ShakeDuration;
    private float ShakeStrength;
    private bool isActive;
    private bool isShaking;
    public ShakeFeature(Transform transform,float Duration, float Strength)
    {
        this.transform = transform;
        ShakeDuration = Duration;
        ShakeStrength = Strength;
    }
    public void SubEvents()
    {
        EventBus<EventActivate>.AddListener(ChangeActivity);
    }
    public void UnSubEvents()
    {
        EventBus<EventActivate>.RemoveListener(ChangeActivity);
    }

    private void ChangeActivity(object sender, EventActivate @event)
    {
        isActive = !isActive;
    }
    public void Shake()
    {
        if (isShaking   ||  !isActive)
            return;
        isShaking = true;
        StartingPos = transform.position;
        transform.DOShakePosition(ShakeDuration, ShakeStrength).OnComplete(ResetPos);
    }
    private void ResetPos()
    {
        transform.position = StartingPos;
        isShaking = false;
    }
}

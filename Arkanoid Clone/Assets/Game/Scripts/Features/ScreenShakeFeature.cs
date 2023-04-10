using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;
using Events.Others;
using DG.Tweening;
using System;

public class ScreenShakeFeature : MonoBehaviour
{
    private bool isActive;
    [SerializeField] private float ShakeDuration;
    [SerializeField] private Vector3 _PositionShakeStrength;
    [SerializeField] private Vector3 _RotationShakeStrength;

    private void OnEnable()
    {
        EventBus<EV_ScreenShake>.AddListener(ChangeActivity);
        EventBus<EV_BallCollide>.AddListener(ScreenShake);
    }
    private void OnDisable()
    {
        EventBus<EV_ScreenShake>.RemoveListener(ChangeActivity);
        EventBus<EV_BallCollide>.RemoveListener(ScreenShake);
    }

    private void ScreenShake(object sender, EV_BallCollide @event)
    {
        if (!isActive)
            return;

        transform.DOComplete();
        transform.DOShakePosition(ShakeDuration, _PositionShakeStrength);
        transform.DOShakeRotation(ShakeDuration, _RotationShakeStrength);
    }

    private void ChangeActivity(object sender, EV_ScreenShake @event)
    {
        isActive = !isActive;
    }
}
